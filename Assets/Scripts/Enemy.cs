using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    public Transform TargetTransform
    {
        set { targetTransform = value; }
        get { return targetTransform; }
    }

    public int Damage { get => damage; }

    [SerializeField] protected Transform targetTransform;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected int health;
    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
