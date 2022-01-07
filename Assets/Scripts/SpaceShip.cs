using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Ship, ITakeDamage, IRotation
{
    private SpaceShipAnim SpaceShipAnim; 

    private const float SPEED = 0.1f;
    private const int HEALTH = 100;
    private const int AMMUNITION = 5;
    private const float ROTATESPEED = 3.0f;

    private Quaternion rotateRight, rotateLeft;
    void Start()
    {
        speed = SPEED;
        health = HEALTH;
        ammunition = AMMUNITION;
        rotateSpeed = ROTATESPEED;

        rotateRight = Quaternion.AngleAxis(rotateSpeed, Vector3.up);
        rotateLeft = Quaternion.AngleAxis(-rotateSpeed, Vector3.up);
    }
    private void FixedUpdate()
    {
        Motion();
        Rotation();
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
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //transform.Translate(new Vector3(0, 0, speed));
        //    rb.AddForce(transform.forward * speed);
        //} 
    }

    public void Rotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= rotateRight;
            //Quaternion.Lerp(transform.rotation, quaternion, rotateSpeed); !!!
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= rotateLeft;
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
