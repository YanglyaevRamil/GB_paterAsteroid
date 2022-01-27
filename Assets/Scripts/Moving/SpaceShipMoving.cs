using UnityEngine;

public class SpaceShipMoving : IMoving
{
    private Transform transformSpaceShip;
    public SpaceShipMoving(Transform transform)
    {
        transformSpaceShip = transform;
    }
    public void Moving(float speed)
    {
        transformSpaceShip.Translate(new Vector3(0, 0, speed));
    }
}
