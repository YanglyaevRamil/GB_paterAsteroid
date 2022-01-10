using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTurnByPlayer : ObjectTurnByPlayer
{
    private void OnEnable()
    {
        ship = GetComponentInParent<Asteroid>().ship;
    }
}
