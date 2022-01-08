using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShip : Ship, ITakeDamage, IRotation
{
    private SpaceShipAnim SpaceShipAnim;


    public Text ScoreText;
    public Text HealthText;
    private int score = 0;
    private const float SPEED = 0.2f;
    private const int HEALTH = 10000;
    private const int AMMUNITION = 50;
    private const float ROTATESPEED = 3.0f;

    private Quaternion rotateRight, rotateLeft;
    void Start()
    {
        //filePath = Application.persistentDataPath + "/save.gamesave";
        StartCoroutine(Score());

        speed = SPEED;
        health = HEALTH;
        ammunition = AMMUNITION;
        rotateSpeed = ROTATESPEED;

        rotateRight = Quaternion.AngleAxis(rotateSpeed, Vector3.up);
        rotateLeft = Quaternion.AngleAxis(-rotateSpeed, Vector3.up);
    }

    IEnumerator Score()
    {
        yield return new WaitForSeconds(1f);
        score++;
        ScoreText.text = "Score: " + score.ToString();
        StartCoroutine(Score());
        
    }
    private void FixedUpdate()
    {
        if (health > 70)
        {
            HealthText.material.color = Color.green;
        }

        if (health <= 70)
        {
            HealthText.material.color = Color.cyan;
        }

        if (health <= 40)
        {
            HealthText.material.color = Color.yellow;
        }

        if (health <= 20)
        {
            HealthText.material.color = Color.red;
        }


        Motion();
        Rotation();
    }
    private void Update()
    {
        if (health <= 0)
        {
            Death();
            health = 0;
        }


        Shooting();
        HealthText.text = "Health: " + health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage = other.GetComponent<IDamage>().Damage;
        DamageTake(damage);
        Debug.Log(health);
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
