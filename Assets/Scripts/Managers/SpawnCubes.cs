﻿using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour {

    public GameObject cubePrefab;
    public float sqrSpawnIndicator = 15;

    
    float spawnMin;
    public float maxSpawnSpeed = 0.25f;
    public float increaseSpawnRate = -0.01f;

    bool isSpawning = true;

    private void Start()
    {
        Timer.ResetTimer();
        spawnMin = Timer.spawnEverySeconds;
    }

    // Update is called once per frame
    void Update () {
        Timer.spawnEverySeconds -= Time.deltaTime;
        if(Timer.spawnEverySeconds <= 0 && isSpawning)
        {
            GameObject newCube = Instantiate(cubePrefab, 
                new Vector3(Random.Range(-sqrSpawnIndicator, sqrSpawnIndicator), 
                Random.Range(-sqrSpawnIndicator, sqrSpawnIndicator), transform.position.z), 
                Quaternion.identity);
            if (spawnMin + increaseSpawnRate > maxSpawnSpeed)
            {
                Timer.spawnEverySeconds = spawnMin += increaseSpawnRate * Time.fixedDeltaTime;
            }
            else
                Timer.spawnEverySeconds = maxSpawnSpeed;
        }
	}

    public void StopSpawnAndClear()
    {
        isSpawning = false;
        spawnMin = 1;
        List<Cube> allCubes = FindObjectsOfType<Cube>().ToList();
        foreach (Cube c in allCubes)
        {
            Destroy(c.gameObject);
        }
    }
}
