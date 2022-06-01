using UnityEngine;

public class SpaceShipModel : ICleanup
{
    private SpaceShipData _spaceShipData;

    private IMoving _moving;
    private IRotation _rotation;
    private IDead _dead—ycle;

    private IShoot _gun;
    public SpaceShipModel(SpaceShipData spaceShipData)
    {
        _spaceShipData = spaceShipData;
        var rbSpaceShip =_spaceShipData.SpaceShipGO?.GetComponent<Rigidbody>();

        _moving = new SpaceShipMoving(
            rbSpaceShip, 
            _spaceShipData.Speed);

        _rotation = new SpaceShipRotation(
            rbSpaceShip,
            _spaceShipData.RotationSpeed);

        _dead—ycle = new SpaceShipDead(
            _spaceShipData.Health);

        _gun = spaceShipData.GunModel;

        _spaceShipData.UserInputModel.OnInputHorizontal += Moving;
        _spaceShipData.UserInputModel.OninputVertical += Rotation;
        _spaceShipData.UserInputModel.OninputFire += Fire;
    }

    public int Health { get { return _dead—ycle.Health; } }
    public int Damage { get { return _spaceShipData.Damage; } }

    public void DamageTake(int damageTaken)
    {
        _dead—ycle.DamageTake(damageTaken);

        if (_dead—ycle.DeathCheck())
        {
            Debug.Log(")= SpaceShip - DEAD =(");
        }
    }

    private void Moving(float dir)
    {
        _moving.Moving(new Vector3(0f, dir, 0f));
    }

    private void Rotation(float dir)
    {
        _rotation.Rotation(_spaceShipData.SpaceShipGO.transform.forward * dir);
    }

    public void Cleanup()
    {
        _spaceShipData.UserInputModel.OnInputHorizontal -= Moving;
        _spaceShipData.UserInputModel.OninputVertical -= Rotation;
    }

    public void Fire(float dir)
    {
        _gun.Shoot();
    }
}
