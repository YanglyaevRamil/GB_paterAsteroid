using UnityEngine;

public class SpaceShipMoving : IMoving
{
    private Transform transformSpaceShip;
    private Rigidbody rigidbodySpaceShip;
    private float speed;
    public SpaceShipMoving(Transform transform, Rigidbody rigidbody, float speed)
    {
        transformSpaceShip = transform;
        this.speed = speed;
        rigidbodySpaceShip = rigidbody;
    }
    public void Moving()
    {
        rigidbodySpaceShip.MovePosition(transformSpaceShip.position + transformSpaceShip.forward * speed);
    }
}
