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

        Vector3 targetPosition;
        if (target == null)
        {
            targetPosition = new Vector3(0, 0, 0);
        }
        else
        {
            targetPosition = target.position;
        }
        normVectorTarget = (targetPosition - transformSpaceObject.position)/(targetPosition - transformSpaceObject.position).magnitude;
    }
    public void Moving()
    {
        transformSpaceObject.position += normVectorTarget * speed;
    }
}
