using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject[] openingObjects;
    public GameObject explenationPanel;
    public Text explenationText;
    public GameObject[] explenationButtons;
    public GameObject okCubesButton;
    public GameObject okCardsButton;
    // Use this for initialization
    void Start () {
        explenationText.fontSize = 75;

        foreach (GameObject o in openingObjects)
        {
            o.SetActive(true);
        }
        explenationPanel.SetActive(false);
    }

    public void GameSelection(string game)
    {
        foreach (GameObject o in explenationButtons)
        {
            o.SetActive(false);
        }

        explenationText.fontSize = 45;

        if(game == "Cubes")
        {
            explenationText.text = "הקוביות מתקיפות! נסה לפוצץ כמה שיותר קוביות כמה שיותר זמן, אל תתן להם לעבור אותך!";
            okCubesButton.SetActive(true);
        }
        if(game == "Cards")
        {
            explenationText.text = "הקלפים התערבבו, יש לך 20 שניות בדיוק להוציא את הקלף השונה בכל החפיסות. אל תתבלבל!";
            okCardsButton.SetActive(true);
        }
    }

    public void OpenCards()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCubes()
    {
        SceneManager.LoadScene(3);
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
