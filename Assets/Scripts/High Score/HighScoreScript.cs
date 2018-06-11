using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public GameObject _name;
    public GameObject _rank;
    public GameObject _time;
    public GameObject _points;

    public void SetScore(string name, string rank, int time, int points)
    {
        _name.GetComponent<Text>().text = name;
        _rank.GetComponent<Text>().text = rank;
        _time.GetComponent<Text>().text = Timer.SecondsToString(time);
        _points.GetComponent<Text>().text = points.ToString();
    }
}
