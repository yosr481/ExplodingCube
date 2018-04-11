using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text correctText;
    public Text wrongText;
    public Text timerText;

    List<GameObject> Cards;
    Sprite[] faces;
    int wrongNum = 0;
    int correctNum = 0;
    float timer = 20;

    private void Start()
    {
        faces = Resources.LoadAll<Sprite>("Faces/");
        Cards = GameObject.FindGameObjectsWithTag("Card").ToList();

        InitComponents();
        FillCards();
    }

    private void Update()
    {
        timer = timer - Time.deltaTime;
        InitComponents();

        if(timer <= 0)
        {
            EndGame();
        }
    }

    void InitComponents()
    {
        correctText.text = correctNum.ToString();
        wrongText.text = wrongNum.ToString();
        timerText.text = timer.ToString("00");

    }

    public void FillCards()
    {
        int rand1 = Random.Range(0, faces.Count());
        int rand2 = Random.Range(0, faces.Count());
        int rand3 = Random.Range(0, Cards.Count);
        Sprite rightAns = faces[rand1];
        Sprite wrongAns = faces[rand2];

        Cards[0].transform.SetSiblingIndex(rand3);
        if (rand1 != rand2)
        {
            Cards[0].GetComponent<Image>().overrideSprite = rightAns;
            for (int i = 1; i < Cards.Count; i++)
            {
                Cards[i].GetComponent<Image>().overrideSprite = wrongAns;
            }

        }
        else
            FillCards();
    }

    public void CheckAnswer(GameObject card)
    {
        if (card == Cards[0]) correctNum++; else wrongNum++;

        FillCards();
    }

    void EndGame()
    {
        GameVar.CorrectNum = correctNum;
        GameVar.WrongNum = wrongNum;
        SceneManager.LoadScene(2);
    }
}
