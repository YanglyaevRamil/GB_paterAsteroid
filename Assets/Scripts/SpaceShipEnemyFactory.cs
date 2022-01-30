using UnityEngine;

public class SpaceShipEnemyFactory
{
    public SpaceShipEnemyBehaviour Create(float speed, int damage, int health, int armor, int ammunition, int pricePoints, Transform targetTransform)
    {
        SpaceShipEnemyBehaviour spaceShipEnemy = Object.Instantiate(Resources.Load<SpaceShipEnemyBehaviour>("SpaceShipEnemy_0"));
        spaceShipEnemy.SpaceShipEnemyInitParametr(speed, damage, health, armor, ammunition, pricePoints);
        spaceShipEnemy.TargetTransform = targetTransform;
        spaceShipEnemy.name = "ShipEnemy";
        return spaceShipEnemy;
    }
}
