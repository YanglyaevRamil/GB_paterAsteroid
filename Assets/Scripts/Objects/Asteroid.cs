using UnityEngine;

public class Asteroid : SpaceObject, IAsteroid
{
    public Asteroid(Transform transform, float speed, Rigidbody rigidbody, Vector3 rotationSpeed, int helth) : 
        base(transform, speed, rigidbody, rotationSpeed,ref helth)
    {
    }
}
