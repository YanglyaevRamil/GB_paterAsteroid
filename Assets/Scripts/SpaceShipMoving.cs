using UnityEngine;

public class SpaceShipMoving : SpaceObjectMoving
{
    private Transform transformSpaceShip;
    public SpaceShipMoving(Transform transform, float speed)
    {
        this.speed = speed;
        transformSpaceShip = transform;
    }
    public override void Moving()
    {
        transformSpaceShip.Translate(new Vector3(0, 0, speed));
    }
}
