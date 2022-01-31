using UnityEngine;

public class SpaceShip : SpaceObject, ISpaceShip
{
    private SpaceObjectRotation spaceShipMovingLeft;
    private SpaceObjectRotation spaceShipMovingRight;

    private int damag;
    public int Damage { get { return damag; } }
    public SpaceShip(int helth, Transform transform, float speed, Quaternion rotationLeft, Quaternion rotationRight, int damag) 
        : base(helth, transform, speed, new Quaternion(),new Vector3(0,0,0))
    {
        spaceObjectMoving = new SpaceShipMoving(transform, speed);
        spaceShipMovingLeft = new SpaceObjectRotation(transform, rotationLeft);
        spaceShipMovingRight = new SpaceObjectRotation(transform, rotationRight);
        this.damag = damag;
    }

    public void RotationLeft()
    {
        spaceShipMovingLeft.Rotation();
    }

    public void RotationRight()
    {
        spaceShipMovingRight.Rotation();
    }
}
