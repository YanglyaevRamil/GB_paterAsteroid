using UnityEngine;

public class ShipEnemy : SpaceObject
{
    private ISpaceShipGun shipEnemyGun;
    public ShipEnemy(int helth, Transform transform, Vector3 direction, int ammunition) : base (helth, transform, direction)
    {
        shipEnemyGun = new SpaceShipGun(ammunition);
    }
    public bool Shooting()
    {
        return shipEnemyGun.Shot();
    }
}
