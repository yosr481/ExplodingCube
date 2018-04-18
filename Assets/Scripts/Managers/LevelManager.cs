using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject[] openingObjects;
    public GameObject explenationPanel;

    // Use this for initialization
    void Start () {
        foreach (GameObject o in openingObjects)
        {
            o.SetActive(true);
        }
        explenationPanel.SetActive(false);
    }

    public void OpenCubes()
    {
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        foreach (GameObject o in openingObjects)
        {
            o.SetActive(false);
        }
        explenationPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
