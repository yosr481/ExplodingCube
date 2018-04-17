using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICubeSceneManager : MonoBehaviour {

    [HideInInspector]
    public int points = 0;
    float timer = 0;

    public Text timerText;
    public Text pointsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        pointsText.text = points.ToString();
        timerText.text = timer.ToString("00:00");
	}
}
