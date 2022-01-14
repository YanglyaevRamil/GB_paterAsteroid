public interface IGun
{
    bool EmptyAmmunition { get; }
    int Ammunition { get; set; }
    public bool Shot();
}
