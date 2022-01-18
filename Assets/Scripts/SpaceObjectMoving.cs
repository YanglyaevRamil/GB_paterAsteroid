using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectMoving : IMoving
{
    public float speed { set; get; }
    public virtual void Moving() { }
}
