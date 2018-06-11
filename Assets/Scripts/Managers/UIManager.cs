using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [HideInInspector]
    public bool overUIElement;

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }

    public void OverUI()
    {
        overUIElement = true;
    }

    public void OffUI()
    {
        overUIElement = false;
    }
}
