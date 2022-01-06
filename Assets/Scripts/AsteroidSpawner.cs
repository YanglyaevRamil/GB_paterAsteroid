using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner
{
    public GameObject ship;

    //[SerializeField] private float startDelay = 3.0f;
    //[SerializeField] private float spawnInterval = 0.2f;
    private float startDelay = 3.0f;
    private float spawnInterval = 0.5f;
    void Start()
    {
        Debug.Log(spawnInterval);
        (objectPrefab.GetComponent<Asteroid>()).ship = ship;
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    protected override void Spawn()
    {
        float rndX = Random.Range(-20.0f, 20.0f);
        Vector3 thePosition = transform.TransformPoint(rndX, 0, 0); 
        
        Instantiate(objectPrefab, thePosition, Quaternion.identity);
    }

    void Update()
    {

    }



}
