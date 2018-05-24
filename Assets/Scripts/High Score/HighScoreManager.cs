using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

    List<HighScore> highScores = new List<HighScore>();
    string connecctionString;
	// Use this for initialization
	void Start () {
        connecctionString = "URI=file:" + Application.dataPath + "/Plugins/HighScoreDB.db";
        DeleteScore(5);
        GetScores();
	}

    public void InsertScore(string name, int points, int seconds)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connecctionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO HighScores(Name,Points,Time) VALUES(\"{0}\",\"{1}\",\"{2}\")", name,points,seconds);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
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
}
