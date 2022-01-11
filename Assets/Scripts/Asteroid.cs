using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject, IDamage
{
    private const int MIN_DAMAGE = 5;
    private const int MAX_DAMAGE = 15;
    private const float MAX_DELETION = 300.0f;
    private const float MIN_SPEED = 0.1f;
    private const float MAX_SPEED = 0.3f;
    private const float DURATION_OF_DEATH = 3.0f;

    private SpriteRenderer spriteRenderer;
    private ParticleSystem partsSystem;
    private SphereCollider sphereCollider;
    private Transform transformShip;
    private Transform transformAsteroid;
    private Vector3 normVecdMoment;
    private int damage;

    public GameObject ship;
    public bool isDead; 
    public int Damage { get => damage; }

    private void OnEnable()
    {
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        partsSystem = GetComponentInChildren<ParticleSystem>();
        transformShip = ship.GetComponent<Transform>();
        sphereCollider = gameObject.GetComponent<SphereCollider>();

        transformAsteroid = gameObject.transform;
        var distance = GetDistanceAtoB(transformShip, transformAsteroid);

        normVecdMoment = (transformShip.position - transformAsteroid.position) / distance;

        partsSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Destruction())
        {
            StartCoroutine(CountToDeath());
        }

        if (isDead == true)
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        Motion();
    }

    private void Update()
    {
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;

        var vec = transformShip.position - transformAsteroid.position;

        if (vec.magnitude > MAX_DELETION)
        {
            Death();
        }
    }

    public override void Motion()
    {
        transform.position += normVecdMoment * speed;
    }

    private bool Destruction()
    {
        spriteRenderer.enabled = false;
        sphereCollider.enabled = false;
        EventAggregator.SpaceObjectDied.Publish(this);
        partsSystem.Play();
        return true;
    }
    IEnumerator CountToDeath()
    {
        yield return new WaitForSecondsRealtime(DURATION_OF_DEATH);
        isDead = true;
        StopCoroutine(CountToDeath());
    }
    public override bool Death()
    {
        //EventAggregator.AsteroidDied.Publish(this);
        //spriteRenderer.enabled = false;
        //sphereCollider.enabled = false;
        Destroy(gameObject);
        return true;
    }

    private float GetDistanceAtoB(Transform a, Transform b)
    {
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;

        var vec = a.position - b.position;
        return vec.magnitude;
    }
}
