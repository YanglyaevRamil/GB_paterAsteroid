using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner
{
    public GameObject ship;

    [SerializeField] private float startDelay = 5f;
    [SerializeField] private float spawnInterval = 1.5f;

    void Start()
    {
        (objectPrefab.GetComponent<Asteroid>()).ship = ship;
        //spawnPosition = transform;
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }


    void Update()
    {

    }



}
