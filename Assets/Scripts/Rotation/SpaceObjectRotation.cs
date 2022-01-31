using UnityEngine;

public class SpaceObjectRotation : IRotation
{
    protected Transform transformSpaceObject;
    protected Quaternion rotation;
    public SpaceObjectRotation(Transform transform, Quaternion rotation)
    {
        transformSpaceObject = transform;
        this.rotation = rotation;
    }
    public void Rotation()
    {
        transformSpaceObject.rotation *= rotation;
    }
}
