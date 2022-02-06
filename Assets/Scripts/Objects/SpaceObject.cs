using UnityEngine;
public class SpaceObject
{
    protected IMoving spaceObjectMoving;
    protected IDead spaceObjectDead;
    protected IRotation spaceObjectRotation;

    public SpaceObject(Transform transform, float speed, Rigidbody rigidbody, Vector3 rotationSpeed,ref int helth)
    {
        spaceObjectMoving = new SpaceObjectMoving(transform, rigidbody, speed);
        spaceObjectRotation = new SpaceObjectRotation(rigidbody, rotationSpeed);
        spaceObjectDead = new SpaceObjectDead(ref helth);
    }
    public void DamageTake(int damageTaken)
    {
        spaceObjectDead.DamageTake(damageTaken);
    }

    public bool DeathCheck()
    {
        return spaceObjectDead.DeathCheck();
    }

    public virtual void Moving(Vector3 dir)
    {
        spaceObjectMoving.Moving(dir);
    }

    public virtual void Rotation(Vector3 dir)
    {
        spaceObjectRotation.Rotation(dir);
    }
}
