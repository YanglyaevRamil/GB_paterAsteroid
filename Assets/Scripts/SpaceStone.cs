using UnityEngine;

public class SpaceStone : SpaceObject
{
    private IMoving spaceStoneMoving;
    private IDead spaceStoneDead;
    private IRotation spaceStoneRotation;
    public SpaceStone(IMoving moving, IDead dead, IRotation rotation)
    {
        spaceStoneMoving = moving;
        spaceStoneDead = dead;
        spaceStoneRotation = rotation;
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

    public override void Rotation(Quaternion quaternion)
    {
        spaceStoneRotation.Rotation(quaternion);
    }
}
