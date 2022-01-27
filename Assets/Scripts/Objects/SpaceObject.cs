using UnityEngine;
public class SpaceObject
{
    protected IMoving spaceObjectMoving;
    protected IDead spaceObjectDead;
    protected IRotation spaceObjectRotation;
    public SpaceObject(int helth, Transform transform, Vector3 direction)
    {
        spaceObjectMoving = new SpaceObjectMoving(transform, direction);
        spaceObjectDead = new SpaceObjectDead(helth);
        spaceObjectRotation = new SpaceObjectRotation(transform);
    }
    public void DamageTake(int damageTaken)
    {
        spaceObjectDead.DamageTake(damageTaken);
    }
    public bool Death()
    {
        EventAggregator.SpaceObjectDied.Publish(this);
        return true;
    }
    public bool DeathCheck()
    {
        return spaceObjectDead.DeathCheck();
    }
    public void Moving(float speed)
    {
        spaceObjectMoving.Moving(speed);
    }
    public void Rotation(Quaternion quaternion)
    {
        spaceObjectRotation.Rotation(quaternion);
    }
}
