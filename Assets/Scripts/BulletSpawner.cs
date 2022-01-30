using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private const float BULLET_SPEED = 2.0f;
    private const int BULLET_DAMAGE = 5;
    private const int BULLET_NUMBER = 20;

    public GameObject playerGameObject;
    private SpaceShipBehaviour player;
    private BulletFactory bulletFactory;
    private SceneObjectPool<BulletBehaviour> bulletPool;
    private BulletBehaviour bullet;
    private void Start()
    {
        player = playerGameObject.GetComponent<SpaceShipBehaviour>();

        bulletFactory = new BulletFactory();
        bulletPool = new SceneObjectPool<BulletBehaviour>(NameManager.POOL_CONTENT_BULLET);

        for (int i = 0; i < BULLET_NUMBER; i++)
        {
            bullet = bulletFactory.Create(BULLET_SPEED, BULLET_DAMAGE);
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
