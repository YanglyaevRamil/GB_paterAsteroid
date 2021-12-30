using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Ship, ITakeDamage
{
    void Start()
    {
        speed = 0.1f;
        health = 100;
        ammunition = 3;
        rotateSpeed = 3.0f;
    }
    private void FixedUpdate()
    {
        Motion();
    }
    private void Update()
    {
        if (health == 0)
        {
            Death();
        }
        Shooting();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            //other.GetComponent<GameObject>()
            //Damage();
        }
    }

    public override bool Death()
    {
        Debug.Log("Death ship");
        Destroy(gameObject);
        return true;
    }
    public override void Motion()
    {
        transform.Translate(new Vector3(0, 0, speed));
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
    }

    public override void Shooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Piw-Piw");
            BulletSpawner.fire = true;
        }
    }
    public void Damage(int damageTaken)
    {
        health -= damageTaken;
    }
}
