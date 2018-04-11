using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour {

    private Transform selectorTransform;
    private Renderer selectorRenderer;
    private Collider2D c2d;

    private void Awake()
    {
        GameObject selectorObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
        selectorObject.name = "selector";
        selectorTransform = selectorObject.transform;
        selectorTransform.parent = gameObject.transform;
        selectorTransform.localPosition = Vector3.zero;

        // create our hitbox for mouseOver detection
        c2d = gameObject.AddComponent<BoxCollider2D>();

        // find our renderer
        selectorRenderer = selectorObject.GetComponent<Renderer>();

        // apply our material
        selectorRenderer.sharedMaterial = Resources.Load("Materials/selctor") as Material;

        // resize to match our card
        SetDefaultSize();

        // turned off by default
        HideSelector();
    }

    private void SetDefaultSize()
    {

        // fetch our default size
        Vector2 size = new Vector2(GameVar.CardWidth, GameVar.CardWidth * GameVar.CardAspect);
        SetSize(size);
    }
    public void SetSize(Vector2 size)
    {
        if (!selectorRenderer)
        {
            Debug.LogError("Error - Selector: Selector not initialised! Cannot SetSize()");
        }

        // the scale we will use
        Vector3 cardScale = new Vector3(size.x, size.y, 1f);

        // set local scale for our quad
        selectorTransform.localScale = cardScale;
    }

    public void ShowSelector()
    {
        selectorRenderer.enabled = true;
    }

    public void HideSelector()
    {
        selectorRenderer.enabled = false;
    }

    void OnMouseEnter()
    {
        ShowSelector();
    }

    void OnMouseExit()
    {
        HideSelector();
    }

    public void SetIgnoreMouseover(bool shouldReact)
    {
        if (c2d != null)
        {
            c2d.enabled = shouldReact;
        }
    }
}
