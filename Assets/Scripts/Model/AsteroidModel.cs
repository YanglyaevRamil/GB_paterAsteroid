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
    private Rigidbody rigidbody;
    private Vector3 direction;
    private Vector3 directionRotation;
    public AsteroidModel(AsteroidData asteroidData)
    {
        this.asteroidData = asteroidData;

        meshRenderer = asteroidData.AsteroidGameObject?.GetComponentInChildren<MeshRenderer>();
        collider = asteroidData.AsteroidGameObject?.GetComponent<Collider>();
        rigidbody = asteroidData.AsteroidGameObject?.GetComponent<Rigidbody>();
        asteroid = new Asteroid(
            asteroidData.AsteroidGameObject.gameObject.transform,
            asteroidData.Speed,
            rigidbody,
            asteroidData.RotationSpeed,
            asteroidData.Health
            );
    }

    public void SetAsteroid(Asteroid asteroid)
    {
        this.asteroid = asteroid;

        meshRenderer.enabled = true;
        collider.enabled = true;
    }

    public void SetAsteroid()
    {
        var targetPos = asteroidData.AsteroidTarget.position;
        var transformPos = asteroidData.AsteroidGameObject.gameObject.transform.position;
        direction = GetDirection(targetPos, transformPos);
        directionRotation = new Vector3(1,1,1);

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
        asteroid.Moving(direction);
    }

    public void Rotation()
    {
        asteroid.Rotation(directionRotation);
    }

    private void ReturnToPool()
    {
        asteroidData.AsteroidGameObject.transform.localPosition = Vector3.zero;
        asteroidData.AsteroidGameObject.transform.localRotation = Quaternion.identity;
        asteroidData.AsteroidGameObject.SetActive(false);
    }

    private Vector3 GetDirection(Vector3 a, Vector3 b)
    {
        return (a - b) / (a - b).magnitude;
    }
}
