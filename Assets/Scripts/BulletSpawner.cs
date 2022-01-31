using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private const float BULLET_SPEED = 2.0f;
    private const int BULLET_DAMAGE = 5;
    private const int BULLET_NUMBER = 20;

    private BulletFactory bulletFactory;
    private SceneObjectPool<BulletBehaviour> bulletPool;
    private BulletBehaviour bullet;
    private void Start()
    {
        bulletFactory = new BulletFactory();
        bulletPool = new SceneObjectPool<BulletBehaviour>(NameManager.POOL_CONTENT_BULLET);

        for (int i = 0; i < BULLET_NUMBER; i++)
        {
            bullet = bulletFactory.Create(BULLET_SPEED, BULLET_DAMAGE);
            bulletPool.AddObjectPool(bullet);
        }
    }
    public void Shoot()
    {
        var bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.gameObject.SetActive(true);
    }
}
