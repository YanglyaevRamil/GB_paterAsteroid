using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsualBullet
{
    private Transform transform;
    private float speed;
    public UsualBullet(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
    }
    public void Motion()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
