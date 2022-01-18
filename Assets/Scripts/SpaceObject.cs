using UnityEngine;

public abstract class SpaceObject
{
    public abstract void DamageTake(int damageTaken);
    public abstract bool Death();
    public abstract bool DeathCheck();
    public abstract void Moving();
    public abstract void Rotation(Quaternion quaternion);
}
