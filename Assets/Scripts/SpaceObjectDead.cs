public class SpaceObjectDead : IDead
{
    public int health { get; set; }
    public SpaceObjectDead(int health)
    {
        this.health = health;
    }
    public void DamageTake(int damageTaken)
    {
        health -= damageTaken;
    }
    public bool DeathCheck()
    {
        if (health <= 0)
        {
            health = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
