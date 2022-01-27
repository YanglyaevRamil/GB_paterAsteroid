using UnityEngine;

public class SpaceShip : SpaceObject
{
    private IGun spaceShipGun;
    public SpaceShip(int helth, Transform transform, int ammunition) : base(helth, transform, new Vector3(0,0,0))
    {
        spaceObjectMoving = new SpaceShipMoving(transform);
        spaceShipGun = new ShipGun(ammunition);
    }
    public void SetShipGun(IGun gun)
    {
        spaceShipGun = gun;
    }
    public int HealthCheck()
    {
        return spaceObjectDead.health;
    }
    public bool Shooting()
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
