using UnityEngine;

public class ShipEnemyMoving : SpaceObjectMoving
{
    private Transform transformShipEnemy;
    private Transform transformShipPlayer;
    private Vector3 normVecdMoment;
    public ShipEnemyMoving(Transform transformShipEnemy, Transform transformShipPlayer, float speed)
    {
        this.transformShipPlayer = transformShipPlayer;
        this.transformShipEnemy = transformShipEnemy;
        this.speed = speed;

        
    }
    public override void Moving()
    {
        normVecdMoment = (transformShipPlayer.position - transformShipEnemy.position) / (transformShipPlayer.position - transformShipEnemy.position).magnitude;
        transformShipEnemy.position += normVecdMoment * speed;
    }
}
