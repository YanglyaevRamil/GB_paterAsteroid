using System;
using UnityEngine;

public class AsteroidModel
{
    public event Action OnDead;

    private AsteroidData asteroidData;

    private IAsteroid asteroid;
    private MeshRenderer meshRenderer;
    private SphereCollider sphereCollider;

    public AsteroidModel(AsteroidData asteroidData)
    {
        this.asteroidData = asteroidData;

        meshRenderer = asteroidData.AsteroidGameObject?.GetComponent<MeshRenderer>();
        sphereCollider = asteroidData.AsteroidGameObject?.GetComponent<SphereCollider>();
        asteroid = new Asteroid(
            asteroidData.Health,
            asteroidData.AsteroidGameObject.gameObject.transform,
            asteroidData.Speed,
            asteroidData.RotationSpeed,
            asteroidData.AsteroidTarget);
    }

    public void SetAsteroid(IAsteroid asteroid)
    {
        this.asteroid = asteroid;
    }

    public void DamageTake(int damageTaken)
    {
        asteroid.DamageTake(damageTaken);
        if (asteroid.DeathCheck())
        {
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
            OnDead?.Invoke();
        }
    }

    public void Moving()
    {
        asteroid.Moving();
    }

    public void Rotation()
    {
        asteroid.Rotation();
    }
    protected void ReturnToPool()
    {
        asteroidData.AsteroidGameObject.transform.localPosition = Vector3.zero;
        asteroidData.AsteroidGameObject.transform.localRotation = Quaternion.identity;
        asteroidData.AsteroidGameObject.SetActive(false);
    }
}
