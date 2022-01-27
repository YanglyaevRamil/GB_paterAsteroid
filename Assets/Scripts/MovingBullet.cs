using UnityEngine;

public class MovingBullet : IMoving
{
    private Transform transform;
    public MovingBullet(Transform transform)
    {
        this.transform = transform;
    }
    public void Moving(float speed)
    {
        transform.Translate(Vector3.forward * speed);
    }
}
