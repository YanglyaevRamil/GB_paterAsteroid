using UnityEngine;

public class ShipEnemyMoving : SpaceObjectMoving
{
    private Transform transformSpaceStone;
    private Vector3 normVecdMoment;
    public ShipEnemyMoving(Transform transformSpaceStone, Transform transformShip, float speed)
    {
        this.transformSpaceStone = transformSpaceStone;
        this.speed = speed;

        normVecdMoment = (transformShip.position - transformSpaceStone.position) / (transformShip.position - transformSpaceStone.position).magnitude;
    }
    public override void Moving()
    {
        transformSpaceStone.position += normVecdMoment * speed;
    }
}
