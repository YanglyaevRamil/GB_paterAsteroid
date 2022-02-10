public interface IDead
{
    public int Health{ get; }
    void DamageTake(int damageTaken);
    public bool DeathCheck();
}
