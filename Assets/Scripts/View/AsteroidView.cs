using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidView : MonoBehaviour, IDamageProvider
{
    public event Action<IDamageProvider> OnCollision;
    public event Action OnEnableEvent;
    public event Action OnEndDestruction;

    public UnityEvent destructionEvent;

    public int Damage { get; set; }

    private void OnEnable()
    {
        OnEnableEvent?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageProvider damage;
        if ((damage = collision.gameObject?.GetComponent<IDamageProvider>()) != null)
        {
            OnCollision?.Invoke(damage);
        }
    }

    public void DestructionAsteroid()
    {
        destructionEvent.Invoke();
        StartCoroutine(CountToDeath());
    }

    private IEnumerator CountToDeath()
    {
        yield return new WaitForSecondsRealtime(AsteroidConst.DURATION_OF_DEATH);
        OnEndDestruction?.Invoke();
        StopCoroutine(CountToDeath());
    }
}
