using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoving
{
    float speed { get; }

    void Moving();
}
