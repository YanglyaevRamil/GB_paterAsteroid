using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPresenter
{
    private BulletView _bulletView;
    private BulletModel _bulletModel;
    public BulletPresenter(BulletView bulletView, BulletModel bulletModel)
    {
        _bulletView = bulletView;
        _bulletModel = bulletModel;
    }
}
