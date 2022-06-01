
using System;
public class AsteroidPresenter
{
    private AsteroidModel _asteroidModel;
    private AsteroidView _asteroidView;

    private Action<IDamageProvider> collision;
    private Action enableEvent;
    private Action endDestruction;

    public AsteroidPresenter(AsteroidModel asteroidModel, AsteroidView asteroidView)
    {
        _asteroidModel = asteroidModel;
        _asteroidView = asteroidView;

        collision = dp =>
        {
            _asteroidModel.DamageTake(dp.Damage);
            _asteroidView.Damage = _asteroidModel.Damage;
        };

        enableEvent = () =>
        {
            _asteroidModel.ReturnFromPool();
        };

        endDestruction = () =>
        {
            _asteroidModel.Dead();
        };

        _asteroidView.OnCollision += collision;
        _asteroidView.OnEnableEvent += enableEvent;
        _asteroidView.OnEndDestruction += endDestruction;
    }

    ~AsteroidPresenter()
    {
        _asteroidView.OnCollision -= collision;
        _asteroidView.OnEnableEvent -= enableEvent;
        _asteroidView.OnEndDestruction -= endDestruction;
    }
}
