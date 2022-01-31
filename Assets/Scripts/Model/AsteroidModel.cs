using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModel
{
    public event Action OnDead;

    private IAsteroid asteroid;
    public AsteroidModel(IAsteroid asteroid)
    {
        this.asteroid = asteroid;
    }

    public void DamageTake(int damageTaken)
    {
        asteroid.DamageTake(damageTaken);
        if (asteroid.DeathCheck())
        {
            OnDead?.Invoke();
        }
    }

    public void Moving()
    {
        asteroid.Moving();
    }

    public void Rotation()
    {
        asteroid.Rotation();
    }
}
