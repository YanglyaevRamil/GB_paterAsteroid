using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipRotation : IRotation
{
    private Transform transformSpaceShip;
    private Quaternion rotateRightY, rotateLeftY;
    public SpaceShipRotation(Transform transform, Quaternion rotateRightY, Quaternion rotateLeftY)
    {
        transformSpaceShip = transform;
        this.rotateRightY = rotateRightY;
        this.rotateLeftY = rotateLeftY;
    }
    public void RotationRightY()
    {
        transformSpaceShip.rotation *= rotateRightY;
    }

    public void RotationLeftY()
    {
        transformSpaceShip.rotation *= rotateLeftY;
    }
}
