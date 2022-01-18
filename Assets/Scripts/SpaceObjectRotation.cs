using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectRotation : IRotation
{
    private Transform transformSpaceShip;
    public SpaceObjectRotation(Transform transform)
    {
        transformSpaceShip = transform;
    }
    public void Rotation(Quaternion rotate)
    {
        transformSpaceShip.rotation *= rotate;
    }
}
