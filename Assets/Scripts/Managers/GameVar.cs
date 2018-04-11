using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVar {

    // CardView vars
    public const float CardFlipDuration = 0.35f;
    // CardView size
    public const float CardWidth = 1.0f;
    public const float CardAspect = 1.554f;

    // Card texture vars
    public const string CardSpriteLocation = "Faces/";
    public const string BackSpriteLocation = "Back/";
    public const string DefaultCardBack = "cardBack_";
    public const string DefaultCardFace = "card_";
    public const int numDecks = 6;
    public const int numFaces = 15;

    // Current game manager instance, if there is one
    public static GameManager GameManager { get; set; }


    public static int CorrectNum;
    public static int WrongNum;
}
