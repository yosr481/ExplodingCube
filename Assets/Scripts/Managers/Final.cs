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

	// Use this for initialization
	void Start () {
        scorePanel.SetActive(true);

        float sum = GameVar.CorrectNum + GameVar.WrongNum;
        float precent = GameVar.CorrectNum / sum;
        float fixedPrecent = precent * 100;

        precentText.text = fixedPrecent.ToString("00.0");
        correctText.text = GameVar.CorrectNum.ToString();
        wrongText.text = GameVar.WrongNum.ToString();
	}

    private void OnMouseDown()
    {
        BackToMainMenu();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
