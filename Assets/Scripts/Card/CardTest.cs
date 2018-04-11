using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour {

    CardView cardViewScript;

    void Awake()
    {
        // create a test card
        GameObject cardView = new GameObject("card");
        cardViewScript = cardView.AddComponent<CardView>();
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(10, 10, 150, 500));

        if (GUILayout.Button("Flip Up"))
        {
            cardViewScript.FlipUp();
        }

        if (GUILayout.Button("Flip Down"))
        {
            cardViewScript.FlipDown();
        }

        GUI.EndGroup();
    }
}
