using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    Color color;

    public GameObject particlePrefab;
    public float speed = 10;


    UICubeSceneManager uiManager;
	// Use this for initialization
	void Start () {
        uiManager = FindObjectOfType<UICubeSceneManager>();
        color = GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
	}

    private void Update()
    {
        if (transform.position.z <= Camera.main.transform.position.z)
            uiManager.ShowLoseMassage();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
    }

    private void OnMouseDown()
    {
        uiManager.points++;
        GameObject newParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        newParticle.GetComponent<ParticleSystem>().startColor = color;

        Destroy(gameObject);
    }
}
