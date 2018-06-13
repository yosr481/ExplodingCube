using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject buttons;
    public GameObject ChooseTimeMassage;

    public void OpenFreeStyle()
    {
        SceneManager.LoadScene("Free Style");
    }

    public void OpenTimeChooser()
    {
        buttons.SetActive(false);
        ChooseTimeMassage.SetActive(true);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void OpenHighScores()
    {
        SceneManager.LoadScene("Scores");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
