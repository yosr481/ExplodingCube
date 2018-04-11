using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // wether or not game input is being accepted right now
    public bool InputEnabled { get; set; }

    public Material rightMat;
    // Currently selected cards waiting to be matched
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
        Sprite rightAns = faces[rand1];
        Sprite wrongAns = faces[rand2];

        if(rand1 != rand2)
        {
            Cards[0].GetComponent<Image>().overrideSprite = rightAns;
            for (int i = 1; i < Cards.Count; i++)
            {
                Cards[i].GetComponent<Image>().overrideSprite = wrongAns;
            }
            
        }
    }
}
