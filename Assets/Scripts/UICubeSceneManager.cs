using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICubeSceneManager : MonoBehaviour {

    [HideInInspector]
    public int points = 0;
    float timer = 0;
    float endTime;

    public Text timerText;
    public Text pointsText;
    public Text endText;
    public GameObject endPanel;

    SpawnCubes spawner;
    bool isPlaying = true;
	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<SpawnCubes>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isPlaying)
            timer += Time.deltaTime;

        pointsText.text = points.ToString();
        timerText.text = timer.ToString("00:00");
	}

    public void ShowLoseMassage()
    {
        spawner.StopSpawnAndClear();
        isPlaying = false;
        endTime = timer;

        PlayerPrefs.SetInt("HighScore", points);
        string beginning = "צברת " + points + " נקודות ב " + timer.ToString("00:00") + " דקות";
        endText.text = beginning;
        endPanel.SetActive(true);
    }
}
