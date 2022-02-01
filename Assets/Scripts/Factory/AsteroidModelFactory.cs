
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModelFactory
{
    private Dictionary<string, List<Asteroid>> asteroidFactory;

    public AsteroidModel Create(int helth, Transform transform, float speed, Quaternion rotation, Transform target, MeshRenderer meshRenderer, SphereCollider sphereCollider)
    {
        var asteroid = new Asteroid(helth, transform, speed, rotation, target);
        AsteroidModel asteroidModel = new AsteroidModel(asteroid, meshRenderer, sphereCollider);
        return asteroidModel;
    }
    public AsteroidModel CreateAsteroidFire()
    {
        return null;
    }

    public AsteroidModel CreateAsteroidIce()
    {
        return null;
    }

    public AsteroidModel CreateAsteroidLava()
    {
        return null;
    }
}
