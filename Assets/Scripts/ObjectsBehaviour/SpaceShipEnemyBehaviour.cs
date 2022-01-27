using UnityEngine;

public class SpaceShipEnemyBehaviour : Enemy, IDamage
{
    [SerializeField] private int armor;
    [SerializeField] private int ammunition;

    private ShipEnemy shipEnemy;
    //private 
    private void OnEnable()
    {
        if (targetTransform != null)
        {
            shipEnemy = new ShipEnemy(health, transform, GetNormVector(transform.position, targetTransform.position), ammunition);
        }
    }
    public void SpaceShipEnemyInitParametr(float speed, int damage, int health, int armor, int ammunition)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.armor = armor;
        this.ammunition = ammunition;
    }
    private void FixedUpdate()
    {
        shipEnemy.Moving(speed);
        if (targetTransform != null)
            transform.LookAt(targetTransform.position);
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
            }
        }
    }
}
