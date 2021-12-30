using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    public static bool fire = false;
    private float timeBetweenShooting = 1f;

    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (fire == true)
        {
            Spawn();
            fire = false;
        }
    }
}
