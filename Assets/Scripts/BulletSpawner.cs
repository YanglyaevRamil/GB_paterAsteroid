using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private BulletFactory bulletFactory;
    private SceneObjectPool<BulletBehaviour> bulletPool;
    private BulletBehaviour bullet;

    private void Start()
    {
        bulletFactory = new BulletFactory();
        bulletPool = new SceneObjectPool<BulletBehaviour>(NameManager.POOL_CONTENT_BULLET);

        for (int i = 0; i < BulletConst.BULLET_NUMBER; i++)
        {
            bullet = bulletFactory.Create(BulletConst.BULLET_SPEED, BulletConst.BULLET_DAMAGE);
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
