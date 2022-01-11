using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : SpaceObject
{
    public int health;
    public int ammunition;
    public float rotateSpeed;

    public abstract bool Shooting();
}