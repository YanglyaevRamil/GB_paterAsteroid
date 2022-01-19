using UnityEngine;

public class SpaceShipEnemy : Enemy, IDamage
{
    [SerializeField] private int armor;

    private ShipEnemy shipEnemy;
    private ShipEnemyMoving shipEnemyMoving;
    private ShipEnemyRotation shipEnemyRotation;
    private ShipEnemyDead shipEnemyDead;
    private ShipEnemyGun shipEnemyGun;
    //private 
    private void OnEnable()
    {
        if (targetTransform != null)
        {
            shipEnemyMoving = new ShipEnemyMoving(transform, targetTransform, speed);
            shipEnemyRotation = new ShipEnemyRotation(transform);
            shipEnemyDead = new ShipEnemyDead(health);
            shipEnemyGun = new ShipEnemyGun();
            shipEnemy = new ShipEnemy(shipEnemyMoving, shipEnemyRotation, shipEnemyDead, shipEnemyGun);
        }
    }
    public void SpaceShipEnemyInitParametr(float speed, int damage, int health, int armor)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.armor = armor;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.gameObject.GetComponent<IDamage>()) != null)
        {
            shipEnemy.DamageTake(damage.Damage - armor);
            if (shipEnemy.DeathCheck())
            {
                shipEnemy.Death();
                ReturnToPool();
                //Destroy(gameObject);
            }
        }
    }
}
