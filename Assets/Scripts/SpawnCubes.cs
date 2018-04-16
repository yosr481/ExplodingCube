using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour {

    public GameObject cubePrefab;

    float timer = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            
            GameObject newCube = Instantiate(cubePrefab, 
                new Vector3(Random.Range(-9,9), Random.Range(-9,9), transform.position.z), 
                Quaternion.identity);
            timer = 1;
        }
	}
}
