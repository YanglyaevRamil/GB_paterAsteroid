using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner
{
    
    private float startDelay = 5f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        spawnPosition = this.transform;

        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

   
    void Update()
    {
        
    }

    

}
