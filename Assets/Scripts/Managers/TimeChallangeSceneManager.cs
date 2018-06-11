using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeChallangeSceneManager : MonoBehaviour {

    [HideInInspector]
    public int points = 0;
    public float endTime;

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
            endTime -= Time.deltaTime;
        if (endTime <= 0)
            ShowLoseMassage();

        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if(hit.collider.tag == "Respawn")
                    {
                        points++;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        pointsText.text = points.ToString();
        timerText.text = Timer.SecondsToString((int)endTime);
	}

    public void ShowLoseMassage()
    {
        isPlaying = false;

        PlayerPrefs.SetInt("HighScore", points);
        string beginning = "צברת " + points + "נקודות ";
        endText.text = beginning;
        endPanel.SetActive(true);

        spawner.StopSpawnAndClear();
    }
}
