using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModel
{
    public event Action OnDead;

    private IAsteroid asteroid;
    private MeshRenderer meshRenderer;
    private SphereCollider sphereCollider;

    public AsteroidModel(IAsteroid asteroid, MeshRenderer meshRenderer, SphereCollider sphereCollider)
    {
        this.asteroid = asteroid;
    }

    public void SetAsteroid(IAsteroid asteroid)
    {
        this.asteroid = asteroid;
    }

    public void DamageTake(int damageTaken)
    {
        asteroid.DamageTake(damageTaken);
        if (asteroid.DeathCheck())
        {
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
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
