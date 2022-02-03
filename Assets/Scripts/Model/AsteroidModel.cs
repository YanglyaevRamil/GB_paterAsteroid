using System;
using UnityEngine;

public class AsteroidModel
{
    public event Action<AsteroidData> OnDead;

    public int Damage { get { return asteroidData.Damage; } }

    private AsteroidData asteroidData;
    private Asteroid asteroid;
    private MeshRenderer meshRenderer;
    private Collider collider;

    public AsteroidModel(AsteroidData asteroidData)
    {
        this.asteroidData = asteroidData;

        meshRenderer = asteroidData.AsteroidGameObject?.GetComponentInChildren<MeshRenderer>();
        collider = asteroidData.AsteroidGameObject?.GetComponent<Collider>();
        asteroid = new Asteroid(
            asteroidData.Health,
            asteroidData.AsteroidGameObject.gameObject.transform,
            asteroidData.Speed,
            asteroidData.RotationSpeed,
            asteroidData.AsteroidTarget);
    }

    public void SetAsteroid(Asteroid asteroid)
    {
        this.asteroid = asteroid;
        meshRenderer.enabled = true;
        collider.enabled = true;
    }

    public void SetAsteroid()
    {
        asteroid = new Asteroid(
            asteroidData.Health,
            asteroidData.AsteroidGameObject.gameObject.transform,
            asteroidData.Speed,
            asteroidData.RotationSpeed,
            asteroidData.AsteroidTarget);

        meshRenderer.enabled = true;
        collider.enabled = true;
    }

    public void SetAsteroidData(AsteroidData asteroidData)
    {
        this.asteroidData = asteroidData;
    }

    public void DamageTake(int damageTaken)
    {
        asteroid.DamageTake(damageTaken);
        if (asteroid.DeathCheck())
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
            OnDead?.Invoke(asteroidData);
        }
    }

    public void Dead()
    {
        ReturnToPool();
    }

    public void Moving()
    {
        asteroid.Moving();
    }

    public void Rotation()
    {
        asteroid.Rotation();
    }

    private void ReturnToPool()
    {
        asteroidData.AsteroidGameObject.transform.localPosition = Vector3.zero;
        asteroidData.AsteroidGameObject.transform.localRotation = Quaternion.identity;
        asteroidData.AsteroidGameObject.SetActive(false);
    }
}
