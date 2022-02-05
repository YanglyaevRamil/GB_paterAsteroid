using UnityEngine;

public class SpaceShip : SpaceObject, ISpaceShip
{
    private SpaceShipRotation spaceShipRotation;
    private SpaceShipMoving spaceShipMoving;
    private int damag;
    public int Damage { get { return damag; } }
    public SpaceShip(int helth, Transform transform, float speed, Vector3 rotationSpeed, int damag, Rigidbody rigidbody) 
        : base(helth, transform, speed, new Quaternion(), null)
    {
        spaceShipMoving = new SpaceShipMoving(transform, rigidbody, speed);
        spaceShipRotation = new SpaceShipRotation(rigidbody, rotationSpeed);
        this.damag = damag;
    }
    public override void Moving()
    {
        spaceShipMoving.Moving();
    }

    public void Rotation(Vector3 vector3)
    {
        spaceShipRotation.Rotation(vector3);
    }
}
