using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    public float Speed { get { return speed; } }

    private Rigidbody rigidbody;
    private float speed;
    public SpaceObjectMoving(Rigidbody rigidbody, float speed)
    {
        this.speed = speed;
        this.rigidbody = rigidbody;
    }

    public void Moving(Vector3 dir)
    {
        rigidbody.MovePosition(rigidbody.position + dir * speed);
    }
}
