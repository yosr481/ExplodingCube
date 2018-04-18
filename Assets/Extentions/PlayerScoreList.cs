using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	int lastChangeCounter;

	// Use this for initialization
	void Start () {
        //DEBUG_INITIAL_SETUP();

        while (transform.childCount > 0)
        {
            Transform c = transform.GetChild(0);
            c.SetParent(null);  // Become Batman
            Destroy(c.gameObject);
        }

        string[] names = ScoreManager.GetPlayerNames("Points");

        foreach (string name in names)
        {
            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(transform);
            go.transform.Find("Username").GetComponent<Text>().text = name;
            go.transform.Find("Points").GetComponent<Text>().text = ScoreManager.GetScore(name, "Points").ToString();
            go.transform.Find("Time").GetComponent<Text>().text = ScoreManager.GetScore(name, "Time").ToString();
        }
    }


    public void DEBUG_INITIAL_SETUP()
    {
        ScoreManager.SetScore("yosr481", "Points", 34);
        ScoreManager.SetScore("yosr482", "Points", 12);
        ScoreManager.SetScore("yosr483", "Time", 61);
        ScoreManager.SetScore("quill18", "Points", 6);
        ScoreManager.SetScore("quill18", "Time", 345);

        ScoreManager.SetScore("bob", "Points", 1000);
        ScoreManager.SetScore("bob", "Time", 14345);

        ScoreManager.SetScore("AAAAAA", "Points", 3);
        ScoreManager.SetScore("BBBBBB", "Points", 2);
        ScoreManager.SetScore("CCCCCC", "Points", 1);


        Debug.Log(ScoreManager.GetScore("quill18", "Points"));
    }

    // Update is called once per frame
    void Update () {

	}
}
