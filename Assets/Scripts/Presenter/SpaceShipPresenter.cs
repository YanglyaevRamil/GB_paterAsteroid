
using System;

public class SpaceShipPresenter
{
    private SpaceShipModel _spaceSpipModel;
    private SpaceShipView _spaceShipView;

    private Action<IDamageProvider> collision;
    public SpaceShipPresenter(SpaceShipModel spaceSpipModel, SpaceShipView spaceShipView)
    {
        _spaceSpipModel = spaceSpipModel;
        _spaceShipView = spaceShipView;

        collision = dp =>
        {
            _spaceSpipModel.DamageTake(dp.Damage);
            _spaceShipView.Damage = _spaceSpipModel.Damage;
        };

        _spaceShipView.OnCollision += collision;
    }

      ~SpaceShipPresenter()
      {
        _spaceShipView.OnCollision -= collision;
      }
}
