using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> Cards;

    Sprite[] faces;

    private void Start()
    {
        faces = Resources.LoadAll<Sprite>("Faces/");
        Cards = GameObject.FindGameObjectsWithTag("Card").ToList();

        FillCards();
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
        if (card == Cards[0]) Debug.Log("Correct!"); else Debug.Log("Wrong!");

        FillCards();
    }
}
