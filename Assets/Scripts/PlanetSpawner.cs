using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : Spawner
{
    private void Start()
    {
        //objectPrefab 
    }
    protected override void Spawn()
    {
        GameObject.Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
