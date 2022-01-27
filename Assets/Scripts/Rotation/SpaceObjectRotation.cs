using UnityEngine;

public class SpaceObjectRotation : IRotation
{
    protected Transform transformSpaceObject;
    public SpaceObjectRotation(Transform transform)
    {
        transformSpaceObject = transform;
    }
    public void Rotation(Quaternion rotate)
    {
        transformSpaceObject.rotation *= rotate;
    }
}
