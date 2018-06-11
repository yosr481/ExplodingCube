using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICubeSceneManager : MonoBehaviour {

    [HideInInspector]
    public int points = 0;
    float endTime;

    public Text timerText;
    public Text pointsText;
    public Text endText;
    public Text nameField;
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
            Timer.timer += Time.deltaTime;

        pointsText.text = points.ToString();
        timerText.text = Timer.SecondsToString((int)Timer.timer);

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.tag == "Respawn")
                    {
                        points++;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    public void ShowLoseMassage()
    {
        isPlaying = false;
        endTime = Timer.timer;

        PlayerPrefs.SetInt("HighScore", points);
        string beginning = "צברת " + points + " נקודות ב " + Timer.SecondsToString((int)endTime) + " דקות";
        endText.text = beginning;
        endPanel.SetActive(true);

        Timer.ResetTimer();
        spawner.StopSpawnAndClear();
    }

    public void GoToHighScore()
    {
        VariablesHolder.InsertVariables(nameField.text, endTime, points);
        SceneManager.LoadScene(2);
    }
}
