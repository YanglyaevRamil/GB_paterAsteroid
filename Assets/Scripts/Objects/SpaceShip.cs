using UnityEngine;

public class SpaceShip : SpaceObject, ISpaceShip
{
    public SpaceShip(int helth, Transform transform) : base(helth, transform, new Vector3(0,0,0))
    {
        spaceObjectMoving = new SpaceShipMoving(transform);
    }
}
