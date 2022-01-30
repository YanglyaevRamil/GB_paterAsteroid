using System;
using System.Timers;
using UnityEngine;

public class PlayerModel
{
    private const float TIMER_TICK = 100.0f; // 0.1 sec
    private const float MILLSEC_MUL = 1000.0f;
    private const int START_AMMUNITION_PLAYER = 20;

    public event Action OnDead;
    public event Action OnShooting;

    public int Health { get { return spaceShip.Health; } }
    public int Ammunition { get { return spaceShipGun.Ammunition; } }
    public bool IsReloading { get => isReloadingGun; }

    private ISpaceShip spaceShip;
    private ISpaceShipGun spaceShipGun;

    private float gunReloadingTime;
    private bool isReloadingGun;
    public PlayerModel(int health, Transform transform, int ammunition, float gunRecoilTime, float gunReloadingTime)
    {
        isReloadingGun = false;
        this.gunReloadingTime = gunReloadingTime;
        spaceShip = new SpaceShip(health, transform);
        spaceShipGun = new SpaceShipGun(ammunition, gunRecoilTime);
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
        if (Health <= 0)
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
            aTimer.Interval = gunReloadingTime * MILLSEC_MUL;
            aTimer.Elapsed += ReloadGunAmmunition;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }
    }

    private void ReloadGunAmmunition(object sender, ElapsedEventArgs e)
    {
        spaceShipGun.Ammunition = START_AMMUNITION_PLAYER;
    }
}
