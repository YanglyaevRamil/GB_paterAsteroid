using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    private const float SPEED = 0.5f;
    private const int HEALTH = 100;
    private const int AMMUNITION = 20;
    private const float ROTATESPEED = 3.0f;
    private const float RECHARGE = 3f;
    private const int DAMAGE = 100;
    private const int OFSET_REY = 2;
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
    private RaycastHit raycastHit;
    Ray ray;
    private Quaternion rotatesRightY, rotatesLeftY;

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
        rotatesRightY = Quaternion.AngleAxis(rotatesSpeedRightY, Vector3.up);
        rotatesLeftY = Quaternion.AngleAxis(rotatesSpeedLeftY, Vector3.up);
        spaceShipMoving = new SpaceShipMoving(transform, speed);
        spaceShipRotation = new SpaceShipRotation(transform);
        spaceShipDead = new SpaceShipDead(health);
        spaceShipGun = new SpaceShipGun(ammunition);
        spaceShip = new SpaceShip(spaceShipMoving, spaceShipRotation, spaceShipDead, spaceShipGun);

        ray = new Ray(transform.position, transform.forward);
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
            spaceShip.Rotation(rotatesLeftY);
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            spaceShip.Rotation(rotatesRightY);
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
    }
    private void Update()
    {
        ray = new Ray(transform.position + new Vector3(0,0,OFSET_REY), transform.forward);
        Physics.Raycast(ray, out raycastHit);
        if (raycastHit.transform != null)
        {
            if (raycastHit.transform.gameObject.CompareTag("Asteroid"))
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
        }
        ammunition = spaceShip.CheckAmmunition();
        health = spaceShip.HealthCheck();
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.gameObject.GetComponent<IDamage>()) != null)
        {
            spaceShip.DamageTake(damage.Damage);
            if (spaceShip.DeathCheck())
            {

                SoundManager.Instance.StopMusic();
                SoundManager.Instance.PlaySound("PlayerDeath");
                spaceShip.Death();
                SoundManager.Instance.PlayMusic("UniverseMusic");
            }
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
