using UnityEngine;

public class Bullet : MonoBehaviour, IDamage
{
    private const float MAX_DELETION = 300.0f;

    public Transform PlayerTransform
    {
        set { playerTransform = value; }
        get { return playerTransform; }
    }

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Transform playerTransform;
    public int Damage { get => damage; }

    private UsualBullet usualBullet;
    private void Start()
    {
        usualBullet = new UsualBullet(transform, speed);
    }
    public void BulletInitParametr(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
    private void FixedUpdate()
    {
        usualBullet.Motion();
    }
    private void Update()
    {
        if ((playerTransform.position - transform.position).magnitude > MAX_DELETION)
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