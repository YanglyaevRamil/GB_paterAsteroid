public interface ISpaceShipGun
{
    int Ammunition { get; set; }
    float GunReloadingTime { get; }
    public bool Shot();
}
