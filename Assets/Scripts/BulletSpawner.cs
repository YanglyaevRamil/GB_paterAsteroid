using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    public static bool fire = false;
    public GameObject ship;
    //private float timeBetweenShooting;
    private int bulletCount;
    private bool isReloading;

    private void Start()
    {
        isReloading = false;
        bulletCount = 3;
        //timeBetweenShooting = 2f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (fire == true)
        {
            if (isReloading == false)
            {
                if (bulletCount > 0)
                {
                    Spawn();
                    fire = false;
                    --bulletCount;
                }
                else
                {
                    isReloading = true;
                    StartCoroutine(Reload());
                    fire = false;
                }
            }
            
        }
    }

    protected override void Spawn()
    {
        var transformShip = ship.GetComponent<Transform>();
        Instantiate(objectPrefab, transform.position, transformShip.rotation);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(6f);
        bulletCount = 3;
        isReloading = false;
        StopCoroutine(Reload());
    }

}
