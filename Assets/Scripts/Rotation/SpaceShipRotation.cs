using UnityEngine;

public class SpaceShipRotation
{
    private Rigidbody rigidbodySpaceShip;
    private Vector3 rotationSpeed;
    public SpaceShipRotation(Rigidbody rigidbody, Vector3 rotationSpeed)
    {
        rigidbodySpaceShip = rigidbody;
        this.rotationSpeed = rotationSpeed;
    }
    public void Rotation(Vector3 dir)
    {
        dir.y *= rotationSpeed.y;
        Quaternion deltaRotation = Quaternion.Euler(dir);
        rigidbodySpaceShip.MoveRotation(rigidbodySpaceShip.rotation * deltaRotation);
    }
}
