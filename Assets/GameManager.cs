using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public Color particleColor;

    public GameObject cube;
    public ParticleSystem particle;

    public bool isDestroyed = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDestroyed)
        {
            particle.startColor = particleColor;
            particle.Play();
            StartCoroutine(CreateNewCube());
            isDestroyed = false;
        }
	}

    IEnumerator CreateNewCube()
    {
        yield return new WaitForSeconds(.2f);

        particle.Stop();

        yield return new WaitForSeconds(.8f);

        GameObject newCube = Instantiate(cube, transform.position, Quaternion.identity) as GameObject;
        Camera.main.backgroundColor = Random.ColorHSV();
    }
}
