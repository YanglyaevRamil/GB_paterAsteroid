using UnityEngine;

public class AsteroidSpawnerFactory
{

    private AsteroidSpawnerData[] _asteroidSpawnerDatas;
    private AsteroidFactory _asteroidFactory;

    public AsteroidSpawnerFactory(AsteroidSpawnerData[] asteroidSpawnerDatas, AsteroidFactory asteroidFactory)
    {
        _asteroidSpawnerDatas = asteroidSpawnerDatas;
        _asteroidFactory = asteroidFactory;
    }

    public (AsteroidSpawnerModel asteroidSpawnerModel, AsteroidSpawnerView asteroidSpawnerView, AsteroidSpawnerPresenter asteroidSpawnerPresenter) GetAsteroidSpawner(AsteroidSpawnerType asteroidSpawnerType)
    {
        return BildAsteroid(asteroidSpawnerType);
    }

    private (AsteroidSpawnerModel asteroidSpawnerModel, AsteroidSpawnerView asteroidSpawnerView, AsteroidSpawnerPresenter asteroidSpawnerPresenter) BildAsteroid(AsteroidSpawnerType asteroidSpawnerType)
    {
        var asteroidSpawnerData = GetAsteroidSpawnerData(asteroidSpawnerType);

        var asteroidSpawnerModel = new AsteroidSpawnerModel(asteroidSpawnerData, _asteroidFactory);
        var asteroidSpawnerView = new GameObject($"{NameManager.ASTEROID_SPAWNER}").AddComponent<AsteroidSpawnerView>();
        var asteroidSpawnerPresenter = new AsteroidSpawnerPresenter(asteroidSpawnerModel, asteroidSpawnerView);

        return (asteroidSpawnerModel, asteroidSpawnerView, asteroidSpawnerPresenter);
    }
    private AsteroidSpawnerData GetAsteroidSpawnerData(AsteroidSpawnerType bulletSpawnerType)
    {
        return Instantiate((int)bulletSpawnerType);
    }

    private AsteroidSpawnerData Instantiate(int index)
    {
        var bulletSpawnerData = Object.Instantiate(_asteroidSpawnerDatas[index]);
        return bulletSpawnerData;
    }
}
