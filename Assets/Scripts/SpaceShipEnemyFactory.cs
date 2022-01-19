using UnityEngine;

public class SpaceShipEnemyFactory
{
    public SpaceShipEnemy Create(float speed, int damage, int health, float armor, Transform targetTransform)
    {
        SpaceShipEnemy spaceShipEnemy = Object.Instantiate(Resources.Load<SpaceShipEnemy>("SpaceShipEnemy_0"));
        spaceShipEnemy.SpaceShipEnemyInitParametr(speed, damage, health, armor);
        spaceShipEnemy.TargetTransform = targetTransform;
        return spaceShipEnemy;
    }
}
