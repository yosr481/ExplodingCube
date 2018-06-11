using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    Color color;

    public GameObject particlePrefab;
    public float speed = 10;
    Collider _collider;

    FreeStyleSceneManager uiManager;
	// Use this for initialization
	void Start () {
        _collider = GetComponent<BoxCollider>();
        
        Material mainMaterial = GetComponent<MeshRenderer>().material;
        uiManager = FindObjectOfType<FreeStyleSceneManager>();
        color = mainMaterial.color = Random.ColorHSV();
        color.a = 255;
    }

    private void Update()
    {
        if (transform.position.z <= Camera.main.transform.position.z + 15)
            uiManager.ShowLoseMassage();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
    }

    /*private void OnMouseDown()
    {
        uiManager.points++;
        GameObject newParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        newParticle.GetComponent<ParticleSystem>().startColor = color;

        Destroy(gameObject);
    }*/
}
