using System.Collections;
using UnityEngine;

public class SpaceShipBehaviour : MonoBehaviour, IDamage
{
    private const float SPEED = 0.5f;
    private const int HEALTH = 100;
    private const int AMMUNITION = 20;
    private const float ROTATESPEED = 3.0f;
    private const float RECHARGE = 3f;
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

    private Animator animator;
    private RaycastHit raycastHit;
    private Ray ray;
    private Quaternion rotatesRightY, rotatesLeftY;

    private SpaceShip spaceShip;

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

        spaceShip = new SpaceShip(health, transform, ammunition);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        spaceShip.Moving(speed);
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
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 500, Color.red);
        if (Physics.Raycast(ray, out raycastHit))
        //if(Input.GetKeyDown(KeyCode.Space))
        {
            if (raycastHit.transform.name == "Asteroid")
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
        }
        else
        {
            shooting = false;
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
