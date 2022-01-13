using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    private const float SPEED = 0.5f;
    private const int HEALTH = 100;
    private const int AMMUNITION = 10;
    private const float ROTATESPEED = 3.0f;
    private const float RECHARGE = 3.0f;
    private const int DAMAGE = 100;
    public int Health { get => health; }
    public bool Shooting { get => shooting; }
    public int Ammunition { get => ammunition; }
    public bool IsReloading { get => isReloadingAmmunition; }

    public int Damage { get => damage; }

    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int ammunition;
    [SerializeField] private float rotatesSpeedRightY;
    [SerializeField] private float rotatesSpeedLeftY;
    [SerializeField] private float rechargeTime;
    [SerializeField] private bool shooting;
    [SerializeField] private bool isReloadingAmmunition;
    [SerializeField] private int damage;
    private SpaceShip spaceShip;
    private SpaceShipMoving spaceShipMoving;
    private SpaceShipRotation spaceShipRotation;
    private SpaceShipDead spaceShipDead;
    private SpaceShipGun spaceShipGun;
    private Animator animator;
    private void Awake()
    {
        speed = SPEED;
        health = HEALTH;
        ammunition = AMMUNITION;
        rotatesSpeedRightY = ROTATESPEED;
        rotatesSpeedLeftY = -ROTATESPEED;
        rechargeTime = RECHARGE;
        isReloadingAmmunition = false;
        damage = DAMAGE;

        spaceShipMoving = new SpaceShipMoving(transform, speed);
        spaceShipRotation = new SpaceShipRotation(transform, Quaternion.AngleAxis(rotatesSpeedRightY, Vector3.up), Quaternion.AngleAxis(rotatesSpeedLeftY, Vector3.up));
        spaceShipDead = new SpaceShipDead(health);
        spaceShipGun = new SpaceShipGun(ammunition);
        spaceShip = new SpaceShip(spaceShipMoving, spaceShipRotation, spaceShipDead, spaceShipGun);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        spaceShip.Moving();
        if (Input.GetKey(KeyCode.A))
        {
            spaceShip.RotationLeftY();
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            spaceShip.RotationRightY();
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooting = spaceShip.Shooting();
            if (!spaceShip.CheckEmptyAmmunition())
            {
                isReloadingAmmunition = false;
            }
            else
            {
                isReloadingAmmunition = true;
                StartCoroutine(ReloadAmmunition());
            }
        }
        else
        {
            shooting = false;
        }
        ammunition = spaceShip.CheckAmmunition();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other is IDamage)
        {
            Debug.Log("IDamage");
        }
        spaceShip.DamageTake(other.GetComponent<IDamage>().Damage);
        if (spaceShip.DeathCheck())
        {
            spaceShip.Death();
        }
    }
    IEnumerator ReloadAmmunition()
    {
        yield return new WaitForSecondsRealtime(rechargeTime);
        isReloadingAmmunition = false;
        spaceShip.ReloadGunAmmunition(AMMUNITION);
        StopCoroutine(ReloadAmmunition());
    }
}
