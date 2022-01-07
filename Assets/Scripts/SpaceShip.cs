using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Ship, ITakeDamage
{

    private const float SPEED = 0.1f;
    private const int HEALTH = 100;
    private const int AMMUNITION = 5;
    private const float ROTATESPEED = 3.0f;
    void Start()
    {
        speed = SPEED;
        health = HEALTH;
        ammunition = AMMUNITION;
        rotateSpeed = ROTATESPEED;
    }
    private void FixedUpdate()
    {
        Motion();
    }
    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
        Shooting();
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage = other.GetComponent<IDamage>().Damage;
        DamageTake(damage);
        Debug.Log(health);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Piw-Piw");
            BulletSpawner.fire = true;
        }
    }
    public void DamageTake(int damageTaken)
    {
        health -= damageTaken;
    }
}
