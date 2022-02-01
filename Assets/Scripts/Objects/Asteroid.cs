using UnityEngine;

public class Asteroid : SpaceObject, IAsteroid
{
    public Asteroid(int helth, Transform transform, float speed, Quaternion rotation, Transform target) : 
        base(helth, transform, speed, rotation, target)
    {
    }
}
