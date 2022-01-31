using UnityEngine;

public class Asteroid : SpaceObject
{
    public Asteroid(int helth, Transform transform, float speed, Quaternion rotation, Vector3 direction) : 
        base(helth, transform, speed, rotation, direction)
    {
    }
}
