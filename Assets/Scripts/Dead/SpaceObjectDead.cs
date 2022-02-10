using UnityEngine;

public class SpaceObjectDead : IDead
{
    public int Health { get { return health; } }
    private int health;

    public SpaceObjectDead(int health)
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
