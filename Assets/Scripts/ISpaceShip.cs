using UnityEngine;

public interface ISpaceShip 
{
    public int Health { get; }
    public void DamageTake(int damageTaken);
    public bool Death();
    public bool DeathCheck();
    public void Moving(float speed);
    public void Rotation(Quaternion quaternion);
}
