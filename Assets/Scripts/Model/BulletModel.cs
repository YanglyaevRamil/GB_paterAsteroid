using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : IFixedExecute, IDamageProvider
{
    public event Action<IDamageProvider> OnDead;

    private BulletData _bulletData;

    private IMoving moving;
    private IRotation rotation;
    private IDead deadÑycle;
    public BulletModel(BulletData bulletData)
    {
        _bulletData = bulletData;

        //moving = new SpaceObjectMoving(
        //    rbAsteroid,
        //    _bulletData.BulletSpeed);
        //
        //rotation = new SpaceObjectRotation(
        //    rbAsteroid,
        //    0);
    }   

    public int Damage => throw new System.NotImplementedException();

    public void FixedExecute()
    {
        throw new System.NotImplementedException();
    }
}
