using UnityEngine;

public class ShipEnemy : SpaceObject
{
    private IGun shipEnemyGun;
    public ShipEnemy(int helth, Transform transform, Vector3 direction, int ammunition) : base (helth, transform, direction)
    {
        shipEnemyGun = new ShipGun(ammunition);
    }
    public bool Shooting()
    {
        return shipEnemyGun.Shot();
    }
}
