using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public Color particleColor;

    public GameObject cube;
    [HideInInspector]
    public ParticleSystem particle;

    public bool isDestroyed = false;

    bool overUIElement;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!overUIElement)
        {
            if (isDestroyed)
            {
                particle = FindObjectOfType<ParticleSystem>();
                if (particle)
                {
                    particle.startColor = particleColor;
                    particle.Play();
                }
                StartCoroutine(CreateNewCube());
                isDestroyed = false;
            }
        }
	}

    IEnumerator CreateNewCube()
    {
        yield return new WaitForSeconds(.2f);

        if(particle)
            particle.Stop();

        yield return new WaitForSeconds(.8f);

        GameObject newCube = Instantiate(cube, transform.position, Quaternion.identity) as GameObject;
        Camera.main.backgroundColor = Random.ColorHSV();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
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
