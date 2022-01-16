using UnityEngine;

public class ShipEnemy : Ship
{
    private IRotation shipEnemyRotation;
    private IMoving shipEnemyMoving;
    private IDead shipEnemyDead;
    private IGun shipEnemyGun;
    public ShipEnemy(IMoving moving, IRotation rotation, IDead dead, IGun gun)
    {
        shipEnemyRotation = rotation;
        shipEnemyMoving = moving;
        shipEnemyDead = dead;
        shipEnemyGun = gun;
    }
    public override void DamageTake(int damageTaken)
    {
        shipEnemyDead.DamageTake(damageTaken);
    }

    public override bool Death()
    {
        EventAggregator.SpaceObjectDied.Publish(this);
        return true;
    }

    public override bool DeathCheck()
    {
        return shipEnemyDead.DeathCheck();
    }

    public override void Moving()
    {
        shipEnemyMoving.Moving();
    }

    public override void Rotation(Quaternion quaternion)
    {
        shipEnemyRotation.Rotation(quaternion);
    }

    public override bool Shooting()
    {
        return shipEnemyGun.Shot();
    }
}
