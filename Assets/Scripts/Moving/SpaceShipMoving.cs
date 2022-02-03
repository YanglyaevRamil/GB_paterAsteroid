using UnityEngine;

public class SpaceShipMoving : IMoving
{
    private Transform transformSpaceShip;
    private Rigidbody rigidbodySpaceShip;
    private float speed;
    public SpaceShipMoving(Transform transform, Rigidbody rigidbody, float speed)
    {
        transformSpaceShip = transform;
        this.speed = 200f;
        rigidbodySpaceShip = rigidbody;
    }
    public void Moving()
    {
        rigidbodySpaceShip.AddForce(transformSpaceShip.forward * speed);
    }
}
