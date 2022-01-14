public class SpaceStone : SpaceObject
{
    private IMoving spaceStoneMoving;
    private IDead spaceStoneDead;
    public SpaceStone(IMoving moving, IDead dead)
    {
        spaceStoneMoving = moving;
        spaceStoneDead = dead;
    }
    public override void DamageTake(int damageTaken)
    {
        spaceStoneDead.DamageTake(damageTaken);
    }
    public override bool Death()
    {
        EventAggregator.SpaceObjectDied.Publish(this);
        return true;
    }
    public override bool DeathCheck()
    {
        return spaceStoneDead.DeathCheck();
    }
    public override void Moving()
    {
        spaceStoneMoving.Moving();
    }
}
