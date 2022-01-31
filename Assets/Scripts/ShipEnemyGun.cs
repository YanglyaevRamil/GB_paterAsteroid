using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyGun : ISpaceShipGun
{
    public bool EmptyAmmunition => throw new System.NotImplementedException();

    public int Ammunition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float GunReloadingTime => throw new System.NotImplementedException();

    public bool Shot()
    {
        throw new System.NotImplementedException();
    }
}
