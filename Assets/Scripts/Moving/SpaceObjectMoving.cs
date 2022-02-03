using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    public float Speed { get { return speed; } }

    private Transform transformSpaceObject;
    private float speed;
    private Vector3 normVectorTarget;
    Vector3 targetPosition;
    public SpaceObjectMoving(Transform transformSpaceObject, Transform target, float speed)
    {
        this.transformSpaceObject = transformSpaceObject;
        this.speed = speed;

        if (target == null)
        {
            targetPosition = new Vector3(0, 0, 0);
        }
        else
        {
            targetPosition = target.position;
        }
        SetTarget();
    }

    public void Moving()
    {
        transformSpaceObject.position += normVectorTarget * speed;
    }

    public void SetTarget()
    {
        normVectorTarget = (targetPosition - transformSpaceObject.position) / (targetPosition - transformSpaceObject.position).magnitude;
    }
}
