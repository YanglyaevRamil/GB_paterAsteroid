using UnityEngine;

public interface ISpaceShip 
{
    public int Health { get; }
    int Damage { get; }
    public void DamageTake(int damageTaken);
    public bool Death();
    public bool DeathCheck();
    public void Moving();
    public void RotationLeft();
    public void RotationRight();
}
