using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    Color color;
    GameManager manager;
	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<GameManager>();
        color = GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            manager.particleColor = color;
            manager.isDestroyed = true;
            Destroy(gameObject);
        }
	}
}
