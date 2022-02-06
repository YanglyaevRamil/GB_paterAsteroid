using UnityEngine;

public class SpaceObjectDead : IDead
{
    private int _health;
    public SpaceObjectDead(ref int health)
    {
        _health = health;
    }
    public void DamageTake(int damageTaken)
    {
        _health -= damageTaken;
    }
    public bool DeathCheck()
    {
        Debug.Log(_health);
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
