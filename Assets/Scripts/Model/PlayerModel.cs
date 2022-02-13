using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModel
{
    private const float MILLSEC_MUL = 1000.0f;

    public event Action OnDead;
    public event Action OnShooting;
    public event Action<int> OnReloadGun;

    public int Ammunition { get { return spaceShipGun.Ammunition; } }
    public int Damage { get { return spaceShip.Damage; } }
    public int Health { get { return spaceShip.Health; } }

    private ISpaceShip spaceShip;
    private ISpaceShipGun spaceShipGun;

    private Timer aTimer;
    public PlayerModel(SpaceShipData spaceShipData, GunData gunData)
    {
        spaceShip =  new SpaceShip(
            spaceShipData.SpaceShipGameObject.transform,
            spaceShipData.SpaceShipGameObject?.GetComponent<Rigidbody>(),
            spaceShipData.Speed,
            spaceShipData.RotationSpeed,
            spaceShipData.Damage,
            spaceShipData.Health);

        Collider collider = spaceShipData.SpaceShipGameObject.GetComponent<Collider>();
        var rigidBody = spaceShipData.SpaceShipGameObject?.GetComponent<Rigidbody>();

        spaceShipGun = new SpaceShipGun(
            gunData.Ammunition,
            gunData.GunRecoilTime,
            gunData.GunReloadingTime);
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

        if (spaceShipGun.Ammunition == 0)
        {
            aTimer = new Timer(spaceShipGun.GunReloadingTime * MILLSEC_MUL);
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
        spaceShipGun.Reload();
        OnReloadGun?.Invoke(spaceShipGun.Ammunition);
    }
}
