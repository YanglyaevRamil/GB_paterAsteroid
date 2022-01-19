using UnityEngine;

public class BulletSpawner : Spawner
{
    private const float BULLET_SPEED = 2.0f;
    private const int BULLET_DAMAGE = 1;
    private const int BULLET_NUMBER = 20;

    public GameObject playerGameObject;
    private Player player;
    private BulletFactory bulletFactory;
    private BulletPool billetPool;
    private Bullet bullet;
    private void Start()
    {
        player = playerGameObject.GetComponent<Player>();

        bulletFactory = new BulletFactory();
        billetPool = new BulletPool(Resources.Load<Bullet>("Bullet_0"));

        for (int i = 0; i < BULLET_NUMBER; i++)
        {
            bullet = bulletFactory.Create(BULLET_SPEED, BULLET_DAMAGE);
            bullet.PlayerTransform = playerGameObject.transform;
            billetPool.AddObjectPool(bullet);
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
            var bullet = billetPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.SetActive(true);
        }
    }
}
