public interface ISpaceShipGun
{
    int Ammunition { get; set; }
    float GunReloadingTime { get; }
    public bool Shot();
    public void Reload();
    public bool CheckGunAmunition();
}
