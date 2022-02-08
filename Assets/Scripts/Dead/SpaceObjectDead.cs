using UnityEngine;

public class SpaceObjectDead : IDead
{
    public int Health { get { return _health; } }

    private int _health;
    public SpaceObjectDead(int health)
    {
        _health = health;
    }
    public void DamageTake(int damageTaken)
    {
        _health -= damageTaken;
    }
    public bool DeathCheck()
    {
        if (_health <= 0)
        {
            _health = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
