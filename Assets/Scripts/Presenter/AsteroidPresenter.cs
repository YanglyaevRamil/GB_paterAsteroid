
public class AsteroidPresenter
{
    private AsteroidModel asteroidModel;
    private AsteroidView asteroidView;

    public AsteroidPresenter(AsteroidModel asteroidModel, AsteroidView asteroidView)
    {
        this.asteroidModel = asteroidModel;
        this.asteroidView = asteroidView;

        asteroidView.OnDamageTaken += DamageTaken;
        asteroidView.OnMoving += Moving;
        asteroidView.OnRotation += Rotation;

        asteroidModel.OnDead += Dead;
    }

    private void Rotation()
    {
        asteroidModel.Rotation();
    }

    private void Moving()
    {
        asteroidModel.Moving();
    }

    private void DamageTaken(IDamage damage)
    {
        asteroidModel.DamageTake(damage.Damage);
    }

    private void Dead()
    {
        asteroidView.Dead();
    }
}
