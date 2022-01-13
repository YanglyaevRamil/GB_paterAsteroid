using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipGun
{
    public bool EmptyAmmunition { get => emptyAmmunition; }
    public int Ammunition { get { return ammunition; } set { ammunition = value; } }

    private int ammunition;
    private bool emptyAmmunition;
    public SpaceShipGun(int ammunition)
    {
        this.ammunition = ammunition;
        emptyAmmunition = false;
    }
    public bool Shot()
    {
        if (ammunition > 1)
        {
            ammunition--;
            emptyAmmunition = false;
        }
        else
        {
            emptyAmmunition = true;
        }
        return !emptyAmmunition;
    }
}
