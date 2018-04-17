using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour {

    public GameObject cubePrefab;
    public float sqrSpawnIndicator = 15;

    float timer = 1;
    float spawnMin;
    float maxSpawnSpeed = 0.25f;
    public float increaseSpawnRate = -0.01f;

    bool isSpawning = true;

    private void Start()
    {
        spawnMin = timer;
    }
    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0 && isSpawning)
        {
            GameObject newCube = Instantiate(cubePrefab, 
                new Vector3(Random.Range(-sqrSpawnIndicator, sqrSpawnIndicator), 
                Random.Range(-sqrSpawnIndicator, sqrSpawnIndicator), transform.position.z), 
                Quaternion.identity);
            if (spawnMin + increaseSpawnRate > maxSpawnSpeed)
                timer = spawnMin += increaseSpawnRate;
            else
                timer = maxSpawnSpeed;
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
