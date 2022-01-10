using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private const float WAIT_SEC = 3.0f;

    public GameObject ship;
    private SpaceShip spaceShip;

    private void Start()
    {
        spaceShip = ship.GetComponent<SpaceShip>();
    }

    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (spaceShip.shooting)
        {
            Spawn();
        }
    }

    protected override void Spawn()
    {
        var transformShip = ship.GetComponent<Transform>();
        Instantiate(objectPrefab, transform.position, transformShip.rotation);
    }
}
