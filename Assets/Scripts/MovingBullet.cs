using UnityEngine;

public class MovingBullet : IMoving
{
    private Transform transform;
    private float speed;
    public MovingBullet(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
    }
    public void Moving()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
