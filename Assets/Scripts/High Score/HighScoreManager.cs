using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

    List<HighScore> highScores = new List<HighScore>();
    string connecctionString;

    public GameObject scorePrefab;
    public Transform scoreParent;

    public int topRanks;
    public int saveScore;
	// Use this for initialization
	void Start () {
        connecctionString = "URI=file:" + Application.dataPath + "/Plugins/HighScoreDB.db";
        CreatTable();
        DeleteExtraScores();
        InsertScore(VariablesHolder.name, VariablesHolder.points, Mathf.RoundToInt(VariablesHolder.seconds));
        ShowScores();
	}

    void CreatTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connecctionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("CREATE TABLE IF NOT EXISTS `HighScores` (`PlayerID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "`Name` TEXT NOT NULL,`Points`	INTEGER NOT NULL,`Time`	INTEGER NOT NULL)");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    public void InsertScore(string name, int points, int seconds)
    {
        GetScores();
        int hsCount = highScores.Count;

        if(highScores.Count > 0)
        {
            HighScore lowestScore = highScores[highScores.Count - 1];

            if(lowestScore != null && saveScore > 0 && highScores.Count >= saveScore && seconds > lowestScore.Seconds)
            {
                DeleteScore(lowestScore.PlayerID);
                hsCount--;
            }
        }
        if(hsCount < saveScore)
        {
            using (IDbConnection dbConnection = new SqliteConnection(connecctionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("INSERT INTO HighScores(Name,Points,Time) VALUES(\"{0}\",\"{1}\",\"{2}\")", name, points, seconds);
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();
                }
            }
        }
    }

    public void GetScores()
    {
        highScores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connecctionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        highScores.Sort();
    }

    public void DeleteScore(int playerID)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connecctionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", playerID);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    void ShowScores()
    {
        GetScores();

        for (int i = 0; i < topRanks; i++)
        {
            if( i <= highScores.Count - 1)
            {
                GameObject tmpGameobject = Instantiate(scorePrefab);
                HighScore tmpHighScore = highScores[i];

                tmpGameobject.GetComponent<HighScoreScript>().SetScore(tmpHighScore.Name, (i + 1) + "#",
                    tmpHighScore.Seconds, tmpHighScore.Points);

                tmpGameobject.transform.SetParent(scoreParent);
            }
        }
    }

    void DeleteExtraScores()
    {
        GetScores();

        if(saveScore <= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScore;
            highScores.Reverse();

            using (IDbConnection dbConnection = new SqliteConnection(connecctionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].PlayerID);
                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();       
                    }

                    dbConnection.Close();
                }
            }
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
