
using System;
using UnityEngine;

public class AsteroidPresenter
{
    public Action<AsteroidData> OnDeadAsteroid;

    private AsteroidModel asteroidModel;
    private AsteroidView asteroidView;

    public AsteroidPresenter(AsteroidModel asteroidModel, AsteroidView asteroidView)
    {
        this.asteroidModel = asteroidModel;
        this.asteroidView = asteroidView;

        asteroidView.OnDamageTaken += DamageTaken;
        asteroidView.OnMoving += Moving;
        asteroidView.OnRotation += Rotation;
        asteroidView.OnEnableEvent += Enable;
        asteroidView.OnGetDamage += GetDamage;
        asteroidView.OnEndDestruction += EndDestruction;

        asteroidModel.OnDead += Dead;
        asteroidModel.OnDead += Destruction;
    }

    private void EndDestruction()
    {
        asteroidModel.Dead();
    }

    private void GetDamage()
    {
        asteroidView.GetDamage(asteroidModel.Damage);
    }

    private void Enable()
    {
        asteroidModel.SetAsteroid();
    }

    private void Rotation()
    {
        asteroidModel.Rotation();
    }

    private void Moving()
    {
        asteroidModel.Moving();
    }

    private void DamageTaken(IDamage damage)
    {
        asteroidModel.DamageTake(damage.Damage);
    }

    private void Dead(AsteroidData asteroidData)
    {
        OnDeadAsteroid?.Invoke(asteroidData);
        
    }

    private void Destruction(AsteroidData asteroidData)
    {
        asteroidView.DestructionAsteroid();
    }
}
