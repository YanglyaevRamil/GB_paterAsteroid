using UnityEngine;

public class SpaceShipMoving : IMoving
{
    private Transform transformSpaceShip;
    private float speed;
    public SpaceShipMoving(Transform transform, float speed)
    {
        transformSpaceShip = transform;
        this.speed = speed;
    }
    public void Moving()
    {
        transformSpaceShip.Translate(new Vector3(0, 0, speed));
    }
}
