using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerModel : IFixedExecute
{
    public Action<IDamageProvider> OnDeadBullet ;

    private SceneObjectPool<BulletView> _bulletPool; 
    private List<BulletModel> _bulletModels;
    private BulletSpawnerData _bulletSpawnerData;
    public BulletSpawnerModel(BulletSpawnerData bulletSpawnerData, BulletFactory bulletFactory)
    {
        _bulletModels = new List<BulletModel>();
        _bulletPool = new SceneObjectPool<BulletView>(NameManager.POOL_CONTENT_BULLET);
        _bulletSpawnerData = bulletSpawnerData;

        for (int i = 0; i < bulletSpawnerData.NumBulletInGrup; i++)
        {
            var bullet = bulletFactory.GetBullet(bulletSpawnerData.BulletType);
            _bulletModels.Add(bullet.bulletModel);
            _bulletPool.AddObjectPool(bullet.bulletView);
        }

        foreach (var item in _bulletModels)
        {
            item.OnDead += DeadBulletEvent;
        }
    }

    ~BulletSpawnerModel()
    {
        foreach (var item in _bulletModels)
        {
            item.OnDead -= DeadBulletEvent;
        }
    }

    public BulletView Spawn()
    {
        return _bulletPool.GetObject();
    }

    public void FixedExecute()
    {
        for (int i = 0; i < _bulletModels.Count; i++)
        {
            _bulletModels[i].FixedExecute();
        }
    }

    public void GetAsteroidFromPool()
    {
        var asteroid = _bulletPool.GetObject();
        asteroid.gameObject.SetActive(true);
        //SetChildrenActiveState(asteroid.transform, true);
    }

    //private void SetChildrenActiveState(Transform gameObjectTransform, bool active)
    //{
    //    foreach (Transform child in gameObjectTransform)
    //    {
    //        child.gameObject.SetActive(active);
    //    }
    //}

    private void DeadBulletEvent(IDamageProvider pointsProvider)
    {
        OnDeadBullet.Invoke(pointsProvider);
    }
}
