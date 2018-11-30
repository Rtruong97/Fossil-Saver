using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyTrSpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject hazardPrefab;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;
    void Update() {
        if (Time.time >= timeToSpawn)
        {

            SpawnHazards();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }
        void SpawnHazards()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i)
                {
                    Instantiate(hazardPrefab, spawnPoints[i].position, Quaternion.identity);
                }

            }
        }

    }

    
