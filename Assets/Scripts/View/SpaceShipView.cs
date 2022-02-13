using System;
using UnityEngine;

public class SpaceShipView : MonoBehaviour, IDamageProvider
{
    public event Action<IDamageProvider> OnCollision;

    public int Damage { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageProvider damage;
        if ((damage = collision.gameObject?.GetComponent<IDamageProvider>()) != null)
        {
            OnCollision?.Invoke(damage);
        }
    }
}
