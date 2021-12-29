using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject
{
    public GameObject ship;
    public float x; 


    private Transform transformShip;
    private Transform transformAsteroid;
    private Vector3 normVecdMoment;
    private int damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }

    private void OnEnable()
    {
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;
        var distance = GetDistanceAtoB(transformShip, transformAsteroid);

        normVecdMoment = (transformShip.position - transformAsteroid.position) / distance;

        speed = Random.Range(0.1f, 0.5f);
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

        x = vec.magnitude;

        if (vec.magnitude > 100.0f)
        {
            Death();
        }
    }

    public override void Motion()
    {
        transform.position += normVecdMoment * speed;
    }
    public override bool Death()
    {
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
