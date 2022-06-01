public class AsteroidSpawnerPresenter
{
    private AsteroidSpawnerModel _asteroidSpawnerModel;
    private AsteroidSpawnerView _asteroidSpawnerView;
    public AsteroidSpawnerPresenter(AsteroidSpawnerModel asteroidSpawnerModel, AsteroidSpawnerView asteroidSpawnerView)
    {
        _asteroidSpawnerModel = asteroidSpawnerModel;
        _asteroidSpawnerView = asteroidSpawnerView;
        _asteroidSpawnerView.OnSpawn += _asteroidSpawnerModel.GetAsteroidFromPool;
    }

    ~AsteroidSpawnerPresenter()
    {
        _asteroidSpawnerView.OnSpawn -= _asteroidSpawnerModel.GetAsteroidFromPool;
    }
}
