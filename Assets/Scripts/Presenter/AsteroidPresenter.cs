using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPresenter
{
    private AsteroidModel asteroidModel;
    private AsteroidView asteroidView;

    public AsteroidPresenter(AsteroidModel asteroidModel, AsteroidView asteroidView)
    {
        this.asteroidModel = asteroidModel;
        this.asteroidView = asteroidView;

        asteroidView.OnDamageTaken += DamageTaken;

        asteroidModel.OnDead += AsteroidDead;
    }

    private void DamageTaken(IDamage damage)
    {
        asteroidModel.DamageTake(damage.Damage);
    }

    private void AsteroidDead()
    {
        
    }
}
