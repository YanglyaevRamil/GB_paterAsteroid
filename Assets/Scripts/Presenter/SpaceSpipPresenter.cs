using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpipPresenter
{
    private SpaceShipModel _spaceSpipModel;
    private SpaceShipView _spaceShipView;

    public SpaceSpipPresenter(SpaceShipModel spaceSpipModel, SpaceShipView spaceShipView)
    {
        _spaceSpipModel = spaceSpipModel;
        _spaceShipView = spaceShipView;

        _spaceShipView.OnCollision += dp =>
        {
            _spaceSpipModel.DamageTake(dp.Damage);
            _spaceShipView.Damage = _spaceSpipModel.Damage;
        };
    }

    public void Execution()
    {

    }

    public void LateExecution()
    {

    }
}
