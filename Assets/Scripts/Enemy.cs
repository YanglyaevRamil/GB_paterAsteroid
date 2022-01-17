using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Enemy : MonoBehaviour
{
    //public Health Health { get; private set; }

    public static Asteroid CreateAsteroidEnemy()
    {
        var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

        //enemy.Health = hp;

        return enemy;
    }
}
