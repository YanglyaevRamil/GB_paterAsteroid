using System;
using UnityEngine;

public class AsteroidModel : IFixedExecute, IPointsProvider
{ 
    public event Action<IPointsProvider> OnDead;

    public int Damage { get { return _asteroidData.Damage; } } 
    public int PricePoints { get { return _asteroidData.PricePoints; } }

    private AsteroidData _asteroidData;

    private MeshRenderer meshRenderer;
    private Collider collider;
    private Rigidbody rbAsteroid;
    private Vector3 direction;
    private Vector3 directionRotation;

    private IMoving moving;
    private IRotation rotation;
    private IDead dead—ycle;

    public AsteroidModel(AsteroidData asteroidData)
    {
        _asteroidData = asteroidData;

        meshRenderer = _asteroidData.AsteroidGO?.GetComponentInChildren<MeshRenderer>();
        collider = _asteroidData.AsteroidGO?.GetComponent<Collider>();
        rbAsteroid = _asteroidData.AsteroidGO?.GetComponent<Rigidbody>();
        direction = GetDirection(
            _asteroidData.AsteroidTarget.position,
            _asteroidData.AsteroidGO.gameObject.transform.position);
        directionRotation = _asteroidData.RotationSpeed;

        moving = new SpaceObjectMoving(
            rbAsteroid,
            _asteroidData.Speed);

        rotation = new SpaceObjectRotation(
            rbAsteroid,
            _asteroidData.RotationSpeed);

        dead—ycle = new SpaceObjectDead(
            _asteroidData.Health);
    }

    public void FixedExecute()
    {
        moving.Moving(direction);
        rotation.Rotation(directionRotation);
    }

    private void InvisibleAsteroidOff()
    {
        meshRenderer.enabled = true;
        collider.enabled = true;
    }

    private void InvisibleAsteroidOn()
    {
        meshRenderer.enabled = false;
        collider.enabled = false;
    }

    public void DamageTake(int damageTaken)
    {
        dead—ycle.DamageTake(damageTaken);
        if (dead—ycle.DeathCheck())
        {
            InvisibleAsteroidOn();
            OnDead?.Invoke(this);
        }
    }

    public void Dead()
    {
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        _asteroidData.AsteroidGO.transform.localPosition = Vector3.zero;
        _asteroidData.AsteroidGO.transform.localRotation = Quaternion.identity;
        _asteroidData.AsteroidGO.SetActive(false);
    }
    public void ReturnFromPool()
    {
        var targetPos = _asteroidData.AsteroidTarget.position;

        float rndX = UnityEngine.Random.Range(AsteroidConst.MIN_ANGL_X_RESP_ASTEROID, AsteroidConst.MAX_ANGL_X_RESP_ASTEROID);
        var transformPos = _asteroidData.AsteroidTarget.TransformPoint(rndX, 0, _asteroidData.DistanceSpawn);
        _asteroidData.AsteroidGO.gameObject.transform.position = transformPos;

        direction = GetDirection(targetPos, transformPos);
        directionRotation = _asteroidData.RotationSpeed;

        InvisibleAsteroidOff();
    }

    private Vector3 GetDirection(Vector3 a, Vector3 b)
    {
        return (a - b) / (a - b).magnitude;
    }
}
