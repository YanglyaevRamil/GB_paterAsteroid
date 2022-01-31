using UnityEngine;

public class SpaceShipEnemyBehaviour : MonoBehaviour, IDamage, IPricePoints
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private int armor;
    [SerializeField] private int ammunition;
    [SerializeField] private int pricePoints;
    [SerializeField] private float gunRecoilTime;
    public int Damage { get => damage; }
    public Transform TargetTransform
    {
        set { targetTransform = value; }
    }

    public int PricePoints { get => pricePoints; }

    private ShipEnemy shipEnemy;
    public delegate void OnShipEnemyDead(IPricePoints shipEnemyPricePoints);
    public static event OnShipEnemyDead onShipEnemyDead;
    //private 
    private void OnEnable()
    {
        if (targetTransform != null)
        {
            shipEnemy = new ShipEnemy(health, transform, speed, GetNormVector(transform.position, targetTransform.position), ammunition, gunRecoilTime);
        }
    }

    public void SpaceShipEnemyInitParametr(float speed, int damage, int health, int armor, int ammunition, int pricePoints)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.armor = armor;
        this.ammunition = ammunition;
        this.pricePoints = pricePoints;
    }

    private void FixedUpdate()
    {
        shipEnemy.Moving();
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
                onShipEnemyDead.Invoke(this);
                //shipEnemy.Death();
                ReturnToPool();
            }
        }
    }
    protected Vector3 GetNormVector(Vector3 a, Vector3 b)
    {
        return (b - a) / (b - a).magnitude;
    }
    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
