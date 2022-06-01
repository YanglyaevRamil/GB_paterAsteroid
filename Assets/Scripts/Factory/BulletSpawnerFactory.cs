using UnityEngine;

public class BulletSpawnerFactory
{
    private BulletSpawnerData[] _bulletSpawnerDatas;
    private BulletFactory _bulletFactory;

    public BulletSpawnerFactory(BulletSpawnerData[] bulletSpawnerDatas, BulletFactory bulletFactory)
    {
        _bulletSpawnerDatas = bulletSpawnerDatas; 
        _bulletFactory = bulletFactory;
    }

    public (BulletSpawnerModel bulletSpawnerModel, BulletSpawnerView bulletSpawnerView, BulletSpawnerPresenter bulletSpawnerPresenter) GetBulletSpawner(BulletSpawnerType bulletSpawnerType, BulletType bulletType)
    {
        return BildSpawnerBullet(bulletSpawnerType, bulletType);
    }

    private (BulletSpawnerModel bulletSpawnerModel, BulletSpawnerView bulletSpawnerView, BulletSpawnerPresenter bulletSpawnerPresenter) BildSpawnerBullet(BulletSpawnerType bulletSpawnerType, BulletType bulletType)
    {
        var bulletSpawnerData = GetBulletSpawnerData(bulletSpawnerType);
        bulletSpawnerData.BulletType = bulletType;

        var bulletSpawnerModel = new BulletSpawnerModel(bulletSpawnerData, _bulletFactory);
        var bulletSpawnerView = new GameObject($"{NameManager.BULLET_SPAWNER}").AddComponent<BulletSpawnerView>();
        var bulletSpawnerPresenter = new BulletSpawnerPresenter(bulletSpawnerModel, bulletSpawnerView);

        return (bulletSpawnerModel, bulletSpawnerView, bulletSpawnerPresenter);
    }

    private BulletSpawnerData GetBulletSpawnerData(BulletSpawnerType bulletSpawnerType)
    {
        return Instantiate((int)bulletSpawnerType);
    }

    private BulletSpawnerData Instantiate(int index)
    {
        var bulletSpawnerData = Object.Instantiate(_bulletSpawnerDatas[index]);
        return bulletSpawnerData;
    }
}