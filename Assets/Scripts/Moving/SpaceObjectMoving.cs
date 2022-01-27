using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    private Transform transformSpaceObject;
    private Vector3 normVectorTarget;
    public SpaceObjectMoving(Transform transformSpaceObject, Vector3 normVectorTarget)
    {
        this.transformSpaceObject = transformSpaceObject;
        this.normVectorTarget = normVectorTarget;
    }
    public void Moving(float speed)
    {
        transformSpaceObject.position += normVectorTarget * speed;
    }
}
