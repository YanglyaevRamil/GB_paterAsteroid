using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShip : Ship, ITakeDamage, IRotation
{
    private const float SPEED = 0.5f;
    private const int HEALTH = 100;
    private const int AMMUNITION = 10;
    private const float ROTATESPEED = 3.0f;
    private const float WAIT_SEC = 3.0f;

    //private Quaternion rotateRightZ, rotateLeftZ;
    private Quaternion rotateRightY, rotateLeftY;
    //private Quaternion originRotation;

    public bool shooting;
    public int shipSpin;
    public bool isReloading;
    void Start()
    {
        speed = SPEED;
        health = HEALTH;
        ammunition = AMMUNITION;
        rotateSpeed = ROTATESPEED;

        //rotateRightZ = Quaternion.AngleAxis(1, Vector3.forward);
        //rotateLeftZ = Quaternion.AngleAxis(-1, Vector3.forward);
        rotateRightY = Quaternion.AngleAxis(rotateSpeed, Vector3.up);
        rotateLeftY = Quaternion.AngleAxis(-rotateSpeed, Vector3.up);

        //originRotation = transform.rotation;

        isReloading = false;
    }

    private void FixedUpdate()
    {
        Motion();
        shipSpin = Rotation();
        //RotationZ();
    }
    private void Update()
    {
        if (health <= 0)
        {
            Death();
            health = 0;
        }

        if (shooting = Shooting() & !isReloading)
        {
            --ammunition;
            if (ammunition == 0)
            {
                isReloading = true;
                StartCoroutine(Reload());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage = other.GetComponent<IDamage>().Damage;
        DamageTake(damage);
    }

    public override bool Death()
    {
        EventAggregator.SpaceObjectDied.Publish(this);
        return true;
    }
    public override void Motion()
    {
        transform.Translate(new Vector3(0, 0, speed));
    }

    public int Rotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= rotateRightY;
            return 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= rotateLeftY;
            return -1;
        }
            return 0;
    }
    public override bool Shooting()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public void DamageTake(int damageTaken)
    {
        health -= damageTaken;
    }

     IEnumerator Reload()
     {
         yield return new WaitForSecondsRealtime(WAIT_SEC);
         ammunition = AMMUNITION;
         isReloading = false;
         StopCoroutine(Reload());
     }
}
