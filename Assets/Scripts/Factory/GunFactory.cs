using UnityEngine;

public class GunFactory
{
    private GunData[] _gunDatas;
    private BulletSpawnerModel _bulletSpawnerModel;
    public GunFactory(GunData[] gunData, BulletSpawnerModel bulletSpawnerModel)
    {
        _gunDatas = gunData;
        _bulletSpawnerModel = bulletSpawnerModel;
    }

    public (GunModel gunModel, GunView gunView, GunPresenter gunPresenter) GetGun(GunType gunType)
    {
        var gunData = GetGunData(gunType);

        return BildGun(gunData);
    }

    private (GunModel gunModel, GunView gunView, GunPresenter gunPresenter) BildGun(GunData gunData)
    {
        var gunModel = new GunModel(gunData);
        var gunView = gunData.GunGO?.GetComponent<GunView>();
        var gunPresenter = new GunPresenter(gunView, gunModel);
        return (gunModel, gunView, gunPresenter);
    }

    private GunData GetGunData(GunType gunType)
    {
        return Instantiate((int)gunType);
    }

    private GunData Instantiate(int index)
    {
        var gunData = Object.Instantiate(_gunDatas[index]);
        gunData.GunGO = new GameObject($"{NameManager.GUN}");
        gunData.GunGO.AddComponent<GunView>();
        gunData.BulletSpawnerModel = _bulletSpawnerModel;
        return gunData;
    }
}
