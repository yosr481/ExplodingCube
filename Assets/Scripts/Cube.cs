using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    Color color;
    GameManagerOld manager;
	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<GameManagerOld>();
        color = GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
	}

    private void OnMouseDown()
    {
        manager.particleColor = color;
        manager.isDestroyed = true;
        Destroy(gameObject);
    }
}
