using UnityEngine;

public class SpaceShip : SpaceObject, ISpaceShip
{
    private int damag;
    public int Damage { get { return damag; } }
    public SpaceShip(Transform transform, Rigidbody rigidbody, float speed, Vector3 rotationSpeed, int damag, ref int helth) 
        : base(transform, speed, rigidbody, rotationSpeed, ref helth)
    {
        this.damag = damag;
    }
}
