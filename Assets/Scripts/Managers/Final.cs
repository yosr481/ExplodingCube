using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

    public Text precentText;
    public Text correctText;
    public Text wrongText;

    public GameObject scorePanel;
    public GameObject questionPanel;

	// Use this for initialization
	void Start () {
        scorePanel.SetActive(true);
        questionPanel.SetActive(false);

        float sum = GameVar.CorrectNum + GameVar.WrongNum;
        float precent = GameVar.CorrectNum / sum;
        float fixedPrecent = precent * 100;

        precentText.text = fixedPrecent.ToString("00.0");
        correctText.text = GameVar.CorrectNum.ToString();
        wrongText.text = GameVar.WrongNum.ToString();
	}

    public void PopingWindow()
    {
        scorePanel.SetActive(false);
        questionPanel.SetActive(true);
    }

    public void AnswerYes()
    {
        SceneManager.LoadScene(3);
    }

    public void AnswerNo()
    {
        SceneManager.LoadScene(0);
    }
}
