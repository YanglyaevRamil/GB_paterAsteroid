using UnityEngine;

public class Asteroid : SpaceObject, IAsteroid
{
    public Asteroid(float speed, Rigidbody rigidbody, Vector3 rotationSpeed, int helth) : 
        base(speed, rigidbody, rotationSpeed, helth)
    {
    }
}
