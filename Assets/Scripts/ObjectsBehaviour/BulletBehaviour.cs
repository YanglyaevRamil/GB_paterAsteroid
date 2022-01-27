using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IDamage
{
    private const float MAX_DELETION = 300.0f;

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Vector3 starrPosition;
    public int Damage { get => damage; }

    private MovingBullet movingBullet;
    private void OnEnable()
    {
        starrPosition = transform.position;
    }
    private void Start()
    {
        movingBullet = new MovingBullet(transform);
    }
    public void BulletInitParametr(float speed, int damage)
    {
        this.damage = damage;
        this.speed = speed;
    }
    private void FixedUpdate()
    {
        movingBullet.Moving(speed);
    }
    private void Update()
    {
        if ((starrPosition - transform.position).magnitude > MAX_DELETION)
        {
            ReturnToPool();
        }
    }
    public bool Death()
    {
        ReturnToPool();
        return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Death();
    }
    private void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}