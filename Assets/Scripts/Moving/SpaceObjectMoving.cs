using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    public float Speed { get { return speed; } }

    private Transform transformSpaceObject;
    private Vector3 normVectorTarget;
    private float speed;
    public SpaceObjectMoving(Transform transformSpaceObject, Vector3 normVectorTarget, float speed)
    {
        this.transformSpaceObject = transformSpaceObject;
        this.normVectorTarget = normVectorTarget;
        this.speed = speed;
    }
    public void Moving()
    {
        transformSpaceObject.position += normVectorTarget * speed;
    }
}
