using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidObjectFactory
{
    public GameObject CreateAsteroidFire()
    {
        return Object.Instantiate(Resources.Load<GameObject>("Asteroid/AsteroidFire"));
    }

    public GameObject CreateAsteroidIce()
    {
        return Object.Instantiate(Resources.Load<GameObject>("Asteroid/AsteroidIce"));
    }

    public GameObject CreateAsteroidLava()
    {
        return Object.Instantiate(Resources.Load<GameObject>("Asteroid/AsteroidLava"));
    }
}
