using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDead
{
    void DamageTake(int damageTaken);
    public bool DeathCheck();
}
