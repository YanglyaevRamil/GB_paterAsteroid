using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMoving : IMoving
{
    public float speed { get; set; }

    private Transform transformSpaceShip;
    public SpaceShipMoving(Transform transform, float speed)
    {
        this.speed = speed;
        transformSpaceShip = transform;
    }
    public void Moving()
    {
        transformSpaceShip.Translate(new Vector3(0, 0, speed));
    }
}
