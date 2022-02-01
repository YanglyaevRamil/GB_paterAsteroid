using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    public float Speed { get { return speed; } }

    private Transform transformSpaceObject;
    private float speed;
    private Vector3 normVectorTarget;
    public SpaceObjectMoving(Transform transformSpaceObject, Transform target, float speed)
    {
        this.transformSpaceObject = transformSpaceObject;
        this.speed = speed;

        GetNormVector(target.position, transformSpaceObject.position);
    }
    public void Moving()
    {
        transformSpaceObject.position += normVectorTarget * speed;
    }
    private Vector3 GetNormVector(Vector3 a, Vector3 b)
    {
        return (b - a) / (b - a).magnitude;
    }
}
