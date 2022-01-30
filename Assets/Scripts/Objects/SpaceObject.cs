using UnityEngine;
public class SpaceObject
{
    public int Health { get { return spaceObjectDead.Health; } }

    protected IMoving spaceObjectMoving;
    protected IDead spaceObjectDead;
    protected IRotation spaceObjectRotation;

    public delegate void OnObjectDead(SpaceObject gameObject);
    public static event OnObjectDead onObjectDead;

    protected SpaceObject(int helth, Transform transform, Vector3 direction)
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
        spaceObjectDead.Health = 0;
        //onObjectDead?.Invoke(this);
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
