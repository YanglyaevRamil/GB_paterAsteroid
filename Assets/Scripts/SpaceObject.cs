using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceObject : MonoBehaviour
{
    public float speed;  

    public abstract bool Death();

    public abstract void Motion();
}
