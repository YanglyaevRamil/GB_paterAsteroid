using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStoneDead : IDead
{
    public int health { get; set; }
    public SpaceStoneDead(int health)
    {
        this.health = health;
    }
    public void DamageTake(int damageTaken)
    {
        health -= damageTaken;
    }
    public bool DeathCheck()
    {
        if (health <= 0)
        {
            health = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
