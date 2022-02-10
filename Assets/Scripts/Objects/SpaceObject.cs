using UnityEngine;
public class SpaceObject
{
    protected IMoving spaceObjectMoving;
    protected IDead spaceObjectDead;
    protected IRotation spaceObjectRotation;

    public int Health { get { return spaceObjectDead.Health; } }

    public SpaceObject(float speed, Rigidbody rigidbody, Vector3 rotationSpeed, int helth)
    {
        spaceObjectMoving = new SpaceObjectMoving(rigidbody, speed);
        spaceObjectRotation = new SpaceObjectRotation(rigidbody, rotationSpeed);
        spaceObjectDead = new SpaceObjectDead(helth);
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
