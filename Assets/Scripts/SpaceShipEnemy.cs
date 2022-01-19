using UnityEngine;

public class SpaceShipEnemy : Enemy, IDamage
{
    private const int DAMAGE_ENEMY_SHIP = 50;
    private const float SPEED_ENEMY_SHIP = 2.0f;
    private const int HEALTH_ENEMY_SHIP = 50;
    private const int ARMOR_ENEMY_SHIP = 50;
    public Transform TargetTransform
    {
        set { targetTransform = value; }
        get { return targetTransform; }
    }

    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private float armor;

    private ShipEnemy shipEnemy;
    private ShipEnemyMoving shipEnemyMoving;
    private ShipEnemyRotation shipEnemyRotation;
    private ShipEnemyDead shipEnemyDead;
    private ShipEnemyGun shipEnemyGun;
    //private 
    private void OnEnable()
    {
        speed = SPEED_ENEMY_SHIP;
        damage = DAMAGE_ENEMY_SHIP;
        health = HEALTH_ENEMY_SHIP;
        armor = ARMOR_ENEMY_SHIP;
        if (targetTransform != null)
        {
            shipEnemyMoving = new ShipEnemyMoving(transform, targetTransform, speed);
            shipEnemyRotation = new ShipEnemyRotation(transform);
            shipEnemyDead = new ShipEnemyDead(health);
            shipEnemyGun = new ShipEnemyGun();
            shipEnemy = new ShipEnemy(shipEnemyMoving, shipEnemyRotation, shipEnemyDead, shipEnemyGun);
        }
    }
    public void SpaceShipEnemyInitParametr(float speed, int damage, int health, float armor)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.armor = armor;
    }
    public int Damage { get => damage; }

    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.gameObject.GetComponent<IDamage>()) != null)
        {
            shipEnemy.DamageTake(damage.Damage);
            if (shipEnemy.DeathCheck())
            {
                shipEnemy.Death();
                ReturnToPool();
                //Destroy(gameObject);
            }
        }
    }
}
