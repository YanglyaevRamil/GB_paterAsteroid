using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    public float Speed { get { return speed; } }

    private Rigidbody rigidbody;
    private Transform transform;
    private float speed;
    private Vector3 normVectorTarget;
    Vector3 targetPosition;
    public SpaceObjectMoving(Transform transform, Rigidbody rigidbody, float speed)
    {
        this.transform = transform;
        this.speed = speed;
        this.rigidbody = rigidbody;
    }

    public void Moving(Vector3 dir)
    {
        rigidbody.MovePosition(rigidbody.position + dir * speed);
    }
}
