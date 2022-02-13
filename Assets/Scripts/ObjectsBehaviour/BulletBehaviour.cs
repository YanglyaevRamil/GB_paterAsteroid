using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IDamageProvider
{


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
        movingBullet = new MovingBullet(transform, speed);
    }

    public void BulletInitParametr(float speed, int damage)
    {
        this.damage = damage;
        this.speed = speed;
    }

    private void FixedUpdate()
    {
        movingBullet.Moving(new Vector3(1,1,1));
    }

    private void Update()
    {
        if ((starrPosition - transform.position).magnitude > BulletConst.MAX_DELETION)
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