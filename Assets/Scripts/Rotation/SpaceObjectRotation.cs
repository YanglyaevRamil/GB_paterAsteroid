using UnityEngine;

public class SpaceObjectRotation : IRotation
{
    protected Rigidbody rigidbody;
    protected Vector3 rotationSpeed;

    public SpaceObjectRotation(Rigidbody rigidbody, Vector3 rotationSpeed)
    {
        this.rigidbody = rigidbody;
        this.rotationSpeed = rotationSpeed;
    }

    public void Rotation(Vector3 dir)
    {
        dir.x *= rotationSpeed.x;
        dir.y *= rotationSpeed.y;
        dir.z *= rotationSpeed.z;
        Quaternion deltaRotation = Quaternion.Euler(dir);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
    }
}
