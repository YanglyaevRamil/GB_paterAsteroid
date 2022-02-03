using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidView : MonoBehaviour, IDamage
{
    private const float DURATION_OF_DEATH = 3.0f;

    public event Action<IDamage> OnDamageTaken;
    public event Action OnMoving;
    public event Action OnRotation;
    public event Action OnEnableEvent;
    public event Action OnGetDamage;
    public event Action OnEndDestruction;
    public UnityEvent destructionEvent;
    private int damage;
    public int Damage
    {
        get
        {
            OnGetDamage?.Invoke();
            return damage;
        }
    }

    private void OnEnable()
    {
        OnEnableEvent?.Invoke();
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

    public void DestructionAsteroid()
    {
        destructionEvent.Invoke();
        StartCoroutine(CountToDeath());
    }
    public void GetDamage(int damage)
    {
        this.damage = damage;
    }

    private IEnumerator CountToDeath()
    {
        yield return new WaitForSecondsRealtime(DURATION_OF_DEATH);
        OnEndDestruction.Invoke();
        StopCoroutine(CountToDeath());
    }
}
