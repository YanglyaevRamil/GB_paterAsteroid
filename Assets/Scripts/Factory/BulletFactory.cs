using UnityEngine;

public class BulletFactory
{
    private BulletData[] _bulletDatas;
    private GameObject[] _bulletGO;

    public BulletFactory(BulletData[] bulletDatas)
    {
        _bulletDatas = bulletDatas;
        _bulletGO = Resources.LoadAll<GameObject>(BulletConst.PRFS_PATH);
    } 

    public (BulletModel bulletModel, BulletView bulletView, BulletPresenter bulletPresenter) GetBullet(BulletType bulletType)
    {
        return BildBullet(bulletType);
    }

    private (BulletModel bulletModel, BulletView bulletView, BulletPresenter bulletPresenter) BildBullet(BulletType bulletType)
    {
        var bulletData = GetBulletData(bulletType);

        var bulletModel = new BulletModel(bulletData);
        var bulletView = bulletData.BulletGO?.GetComponent<BulletView>();
        var bulletPresenter = new BulletPresenter(bulletView, bulletModel);

        return (bulletModel, bulletView, bulletPresenter);
    }

    private BulletData GetBulletData(BulletType bulletType)
    {
        return Instantiate((int)bulletType);
    }

    private BulletData Instantiate(int index)
    {
        var bulletData = Object.Instantiate(_bulletDatas[index]);
        bulletData.BulletGO = Object.Instantiate(_bulletGO[index]);
        return bulletData;
    }

}