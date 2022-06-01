using UnityEngine;

public class GunModel : IShoot
{
    private GunData _gunData;

    private BulletSpawnerModel _armorPool;
    private IShoot _shooting;
    public GunModel(GunData gunData)
    {
        _gunData = gunData;
        _shooting = new Shooting(
            gunData.Ammunition,
            gunData.GunRecoilTime,
            gunData.GunReloadingTime
            );
        _armorPool = gunData.BulletSpawnerModel;
    }


    public bool Shoot()
    {
        bool b;
        if (b = _shooting.Shoot())
        {
            var bullet = _armorPool.Spawn();
            bullet.transform.position = _gunData.GunGO.transform.position;
            bullet.transform.rotation = _gunData.GunGO.transform.rotation;
            bullet.gameObject.SetActive(true);
        }
        return b;
    }
}
