using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDead
{
    public int Health{ get; }
    void DamageTake(int damageTaken);
    public bool DeathCheck();
}
