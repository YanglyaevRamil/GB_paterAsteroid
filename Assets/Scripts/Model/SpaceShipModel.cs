using UnityEngine;

public class SpaceShipModel : IMoving, IRotation, IDead
{
    private SpaceShipData _spaceShipData;

    private IMoving moving;
    private IRotation rotation;
    private IDead dead—ycle;
    public SpaceShipModel(SpaceShipData spaceShipData)
    {
        _spaceShipData = spaceShipData;
        var rbSpaceShip =_spaceShipData.SpaceShipGameObject?.GetComponent<Rigidbody>();

        moving = new SpaceShipMoving(
            rbSpaceShip, 
            _spaceShipData.Speed);

        rotation = new SpaceShipRotation(
            rbSpaceShip,
            _spaceShipData.RotationSpeed);

        dead—ycle = new SpaceShipDead(
            _spaceShipData.Health);
    }

    public int Health { get { return dead—ycle.Health; } }
    public int Damage { get { return _spaceShipData.Damage; } }

    public void DamageTake(int damageTaken)
    {
        dead—ycle.DamageTake(damageTaken);
    }

    public bool DeathCheck()
    {
        return dead—ycle.DeathCheck();
    }

    public void Moving(Vector3 dir)
    {
        moving.Moving(dir);
    }

    public void Rotation(Vector3 dir)
    {
        rotation.Rotation(dir);
    }
}
