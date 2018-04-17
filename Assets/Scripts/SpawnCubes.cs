using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour {

    public GameObject cubePrefab;
    public float sqrSpawnIndicator = 15;

    float timer = 1;
    
    bool isSpawning = true;

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0 && isSpawning)
        {
            GameObject newCube = Instantiate(cubePrefab, 
                new Vector3(Random.Range(-sqrSpawnIndicator, sqrSpawnIndicator), 
                Random.Range(-sqrSpawnIndicator, sqrSpawnIndicator), transform.position.z), 
                Quaternion.identity);
            timer = 1;
        }
	}

    public void StopSpawnAndClear()
    {
        isSpawning = false;

        List<Cube> allCubes = FindObjectsOfType<Cube>().ToList();
        foreach (Cube c in allCubes)
        {
            Destroy(c.gameObject);
        }
    }
}
