public class SpaceObjectDead : IDead
{
    public int Health { get; set; }
    public SpaceObjectDead(int health)
    {
        this.Health = health;
    }
    public void DamageTake(int damageTaken)
    {
        Health -= damageTaken;
    }
    public bool DeathCheck()
    {
        if (Health <= 0)
        {
            Health = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
