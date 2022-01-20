using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private const float BULLET_SPEED = 2.0f;
    private const int BULLET_DAMAGE = 5;
    private const int BULLET_NUMBER = 20;

    public GameObject playerGameObject;
    private Player player;
    private BulletFactory bulletFactory;
    private BulletPool bulletPool;
    private Bullet bullet;
    private void Start()
    {
        player = playerGameObject.GetComponent<Player>();

        bulletFactory = new BulletFactory();
        bulletPool = new BulletPool(Resources.Load<Bullet>("Bullet_0"));

        for (int i = 0; i < BULLET_NUMBER; i++)
        {
            bullet = bulletFactory.Create(BULLET_SPEED, BULLET_DAMAGE);
            bullet.PlayerTransform = playerGameObject.transform;
            bulletPool.AddObjectPool(bullet);
        }
    }
    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (player.Shooting)
        {
            var bullet = bulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.SetActive(true);
        }
    }
}
