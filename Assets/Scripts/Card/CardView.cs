using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {

    GameObject face;
    GameObject back;
    Renderer faceRenderer;
    Renderer backRenderer;

    BoxCollider2D c2d;

    Flip flipController;

    public int refIdx = 0;

    // Use this for initialization
    void Awake () {
        InitGameObject();
	}
	
	void InitGameObject()
    {
        // Create front card (Flipped 180).
        face = GameObject.CreatePrimitive(PrimitiveType.Quad);
        face.name = "face";
        face.transform.parent = transform;
        Quaternion faceRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        face.transform.localRotation = faceRotation;
        face.transform.localPosition = Vector3.zero;
        faceRenderer = face.GetComponent<Renderer>();

        // Create back.
        back = GameObject.CreatePrimitive(PrimitiveType.Quad);
        back.name = "back";
        back.transform.parent = transform;
        back.transform.localPosition = Vector3.zero;
        backRenderer = back.GetComponent<Renderer>();

        // Create our hitbox for mouseOver detection.
        c2d = gameObject.AddComponent<BoxCollider2D>();

        flipController = gameObject.AddComponent<Flip>();

        // Set the default size and aspect of our card.
        SetDefaultSize();
        SetDefaultFaceTexture();
        SetDefaultBackTexture();
    }

    void SetDefaultSize()
    {
        // Fetch our default size.
        Vector2 size = new Vector2(GameVar.CardWidth, GameVar.CardWidth * GameVar.CardAspect);
        SetSize(size);
    }

    void SetDefaultFaceTexture()
    {
        Material mat = Resources.Load("Materials/card_face") as Material;

        if (mat)
            faceRenderer.sharedMaterial = mat;
    }

    void SetDefaultBackTexture()
    {
        Material mat = Resources.Load("Materials/card_back") as Material;

        if (mat)
            backRenderer.sharedMaterial = mat;
    }

    void SetSize(Vector2 size)
    {
        if (!face || !back)
            Debug.LogError("Error - Card: Card back or front not initialised! Cannot SetSize()");

        // The scale we will use.
        Vector3 cardScale = new Vector3(size.x, size.y, 1f);

        // Set local scale for our card quads.
        face.transform.localScale = cardScale;
        back.transform.localScale = cardScale;

        // Update our hitbox.
        c2d.size = cardScale;
    }

    public void SetFaceTexture(Texture2D texture)
    {
        if (!faceRenderer)
            Debug.LogError("Error - Card: Card back or front not initialised! Cannot SetFaceTexture()");

        faceRenderer.material.SetTexture("_MainTex", texture);
    }

    public void SetBackTexture(Texture2D texture)
    {
        if (!faceRenderer)
            Debug.LogError("Error - Card: Card back or front not initialised! Cannot SetBackTexture()");

        backRenderer.material.SetTexture("_MainTex", texture);
    }

    private void ResetFlipController()
    {
        if (flipController.enabled)
        {
            flipController.StopAllCoroutines();
            flipController.enabled = false;
        }
    }

    public void FlipUp()
    {
        ResetFlipController();
        flipController.TargetFacing = 0;
        flipController.enabled = true;
    }

    public void FlipDown()
    {
        ResetFlipController();
        flipController.TargetFacing = 1;
        flipController.enabled = true;
    }

    IEnumerator OnMouseDown()
    {

        FlipUp();

        // we will re-visit this method in Part 2

        yield return null;
    }
}
