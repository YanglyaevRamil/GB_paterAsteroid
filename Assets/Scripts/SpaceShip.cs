using System.Collections;
using UnityEngine;

public class SpaceShip : Ship
{
    private IRotation spaceShipRotation;
    private IMoving spaceShipMoving;
    private IDead spaceShipDead;
    private SpaceShipGun spaceShipGun;
    public SpaceShip(IMoving moving, IRotation rotation, IDead dead, SpaceShipGun gun)
    {
        spaceShipMoving = moving;
        spaceShipRotation = rotation;
        spaceShipDead = dead;
        spaceShipGun = gun;
    }
    public override void RotationRightY()
    {
        spaceShipRotation.RotationRightY();
    }
    public override void RotationLeftY()
    {
        spaceShipRotation.RotationLeftY();
    }
    public override void Moving()
    {
        spaceShipMoving.Moving();
    }
    public override bool Death()
    {
        EventAggregator.SpaceObjectDied.Publish(this);
        return true;
    }
    public override void DamageTake(int damageTaken)
    {
        spaceShipDead.DamageTake(damageTaken);
    }
    public override bool DeathCheck()
    {
        return spaceShipDead.DeathCheck();
    }
    public int HealthCheck()
    {
        return spaceShipDead.health;
    }
    public override bool Shooting()
    {
        return spaceShipGun.Shot();
    }
    public bool CheckEmptyAmmunition()
    {
        return spaceShipGun.EmptyAmmunition;
    }
    public void ReloadGunAmmunition(int ammunition)
    {
        spaceShipGun.Ammunition = ammunition;
    }
    public int CheckAmmunition()
    {
        return spaceShipGun.Ammunition;
    }
}
