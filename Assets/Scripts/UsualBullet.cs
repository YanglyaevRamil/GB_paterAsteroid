using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsualBullet
{
    private const int USUAL_BULLET_DAMAGE = 1;
    public int Damage { get { return damage; } }
    private Transform transform;
    private float speed;
    private int damage;
    public UsualBullet(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
        damage = USUAL_BULLET_DAMAGE;
    }
    public void Motion()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
