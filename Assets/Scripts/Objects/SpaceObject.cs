using UnityEngine;
public class SpaceObject
{
    public int Health { get { return spaceObjectDead.Health; } }

    protected IMoving spaceObjectMoving;
    protected IDead spaceObjectDead;
    protected IRotation spaceObjectRotation;

    public SpaceObject(int helth, Transform transform, float speed, Quaternion rotation, Transform target)
    {
        spaceObjectMoving = new SpaceObjectMoving(transform, target, speed);
        spaceObjectDead = new SpaceObjectDead(helth);
        spaceObjectRotation = new SpaceObjectRotation(transform, rotation);
    }
    public void DamageTake(int damageTaken)
    {
        spaceObjectDead.DamageTake(damageTaken);
    }

    public bool Death()
    {
        //spaceObjectDead.Health = 0;
        return true;
    }

    public bool DeathCheck()
    {
        return spaceObjectDead.DeathCheck();
    }

    public virtual void Moving()
    {
        spaceObjectMoving.Moving();
    }

    public virtual void Rotation()
    {
        spaceObjectRotation.Rotation();
    }
}
