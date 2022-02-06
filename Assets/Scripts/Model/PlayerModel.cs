using System;
using System.Timers;
using UnityEngine;

public class PlayerModel
{
    private const float MILLSEC_MUL = 1000.0f;
    private const int START_AMMUNITION_PLAYER = 20;

    public event Action OnDead;
    public event Action OnShooting;

    public int Ammunition { get { return spaceShipGun.Ammunition; } }
    public int Damage { get { return spaceShip.Damage; } }

    private ISpaceShip spaceShip;
    private ISpaceShipGun spaceShipGun;

    private bool isReloadingGun;
    private int health;
    public PlayerModel(SpaceShipData spaceShipData, ISpaceShipGun spaceShipGun)
    {
        isReloadingGun = false;
        health = spaceShipData.Health;

        spaceShip = new SpaceShip(
            spaceShipData.SpaceShipGameObject.transform,
            spaceShipData.SpaceShipGameObject?.GetComponent<Rigidbody>(),
            spaceShipData.Speed,
            spaceShipData.RotationSpeed,
            spaceShipData.Damage,
            ref health);

        this.spaceShipGun = spaceShipGun;
    }

    public void SetSpaceShip(ISpaceShip spaceShip)
    {
        this.spaceShip = spaceShip;
    }

    public void SetSpaceShipGun(ISpaceShipGun gun)
    {
        spaceShipGun = gun;
    }

    public void DamageTake(int damag)
    {
        spaceShip.DamageTake(damag);
        if (spaceShip.DeathCheck())
        {
            OnDead?.Invoke();
        }
    }

    public void Shooting()
    {
        if (spaceShipGun.Shot())
        {
            OnShooting?.Invoke();
        }
        else
        {
            Timer aTimer = new Timer();
            aTimer.Interval = spaceShipGun.GunReloadingTime * MILLSEC_MUL;
            aTimer.Elapsed += ReloadGunAmmunition;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }
    }

    public void Rotation(Vector3 dir)
    {
        spaceShip.Rotation(dir);
    }

    public void Moving(Vector3 dir)
    {
        spaceShip.Moving(dir);
    }

    private void ReloadGunAmmunition(object sender, ElapsedEventArgs e)
    {
        spaceShipGun.Ammunition = START_AMMUNITION_PLAYER;
    }
}
