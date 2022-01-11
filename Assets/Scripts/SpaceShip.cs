using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShip : Ship, ITakeDamage, IRotation
{
    private const float SPEED = 0.5f;
    private const int HEALTH = 1000;
    private const int AMMUNITION = 10;
    private const float ROTATESPEED = 3.0f;
    private const float WAIT_SEC = 3.0f;

    private Quaternion rotateRight, rotateLeft;

    public bool shooting;
    public int shipSpin;
    public bool isReloading;
    void Start()
    {
        speed = SPEED;
        health = HEALTH;
        ammunition = AMMUNITION;
        rotateSpeed = ROTATESPEED;

        rotateRight = Quaternion.AngleAxis(rotateSpeed, Vector3.up);
        rotateLeft = Quaternion.AngleAxis(-rotateSpeed, Vector3.up);

        isReloading = false;
    }

    private void FixedUpdate()
    {
        Motion();
        shipSpin = Rotation();
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
        SceneManager.LoadScene("DeathScreen");
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

    public int Rotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= rotateRight;
            return 1;
            //Quaternion.Lerp(transform.rotation, quaternion, rotateSpeed); !!!
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= rotateLeft;
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
