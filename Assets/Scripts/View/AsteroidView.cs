using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    public event Action<IDamage> OnDamageTaken;
    public event Action OnMoving;
    public event Action OnRotation;

    private void OnEnable()
    {
    }
    
    private void FixedUpdate()
    {
        OnMoving?.Invoke();
        OnRotation?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.GetComponent<IDamage>()) != null)
        {
            OnDamageTaken?.Invoke(damage);
        }
    }

    public void Dead()
    {
        DestructionAsteroid();
    }

    private void DestructionAsteroid()
    {

    }
}
