using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTextureManager : MonoBehaviour {

    public static CardTextureManager _instance;
    public static CardTextureManager GetInstance()
    {

        if (_instance == null)
        {
            _instance = new CardTextureManager();
            _instance.Initialize();
        }

        return _instance;
    }

    private List<Texture2D> faceTextures;
    private List<Texture2D> deckTextures;

    private int maxFaceTextures = GameVar.numFaces;

    public CardTextureManager()
    {

    }

    private void Initialize()
    {

        LoadFaceTextures(maxFaceTextures);
        LoadDeckTextures();
    }

    public Texture2D GetFaceTexture(int faceIndex)
    {
        if (faceTextures == null || faceIndex < 0 || faceIndex > maxFaceTextures)
        {
            Debug.LogError("Error: Cannot get face texture for index: " + faceIndex);
            return null;
        }

        return faceTextures[faceIndex];
    }

    public int GetNumDeckTextures()
    {
        if (deckTextures != null)
            return deckTextures.Count - 1;

        return 0;
    }

    public Texture2D GetDeckTexture(int deckIndex)
    {
        if (deckTextures == null || deckIndex < 0 || deckIndex > deckTextures.Count - 1)
        {
            Debug.LogError("Error: Cannot get deck texture for index: " + deckIndex);
            return null;
        }

        Debug.Log("Returning Deck Texture: " + deckIndex);

        return deckTextures[deckIndex];
    }

    private void LoadDeckTextures()
    {
        deckTextures = new List<Texture2D>();

        int count = GameVar.numDecks;
        string path = GameVar.CardSpriteLocation + GameVar.DefaultCardBack;

        for (int i = 0; i < count + 0; i++)
        {
            string spriteString = path + i.ToString();
            Texture2D t2d = Resources.Load(spriteString) as Texture2D;
            deckTextures.Add(t2d);
        }
    }

    private void LoadFaceTextures(int required)
    {

        if (required < 1 || required > maxFaceTextures)
        {
            Debug.LogError("Error: Cannot load face textures.");
            return;
        }

        faceTextures = new List<Texture2D>();
        int count = GameVar.numFaces;
        string path = GameVar.CardSpriteLocation + GameVar.DefaultCardFace;

        for (int i = 1; i < count + 1; i++)
        {
            string spriteString = path + i.ToString();
            Texture2D t2d = Resources.Load(spriteString) as Texture2D;
            faceTextures.Add(t2d);
        }
    }
}


