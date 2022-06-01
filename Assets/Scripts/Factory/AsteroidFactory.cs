using UnityEngine;

public class AsteroidFactory
{
    private AsteroidData[] _asteroidDatas;
    private GameObject[] _asteroidGameObjekts;
    private Transform _targetTransform;

    public AsteroidFactory(AsteroidData[] asteroidDatas, Transform targetTransform)
    {
        _asteroidDatas = asteroidDatas;
        _asteroidGameObjekts = Resources.LoadAll<GameObject>(AsteroidConst.PRFS_PATH);
        _targetTransform = targetTransform;
    }

    public (AsteroidModel asteroidModel, AsteroidView asteroidView, AsteroidPresenter asteroidPresenter) GetAsteroid(AsteroidType asteroidType)
    {
        var asteroidData = GetAsteroidData(asteroidType);

        return (BildAsteroid(asteroidData));
    }

    private (AsteroidModel asteroidModel, AsteroidView asteroidView, AsteroidPresenter asteroidPresenter) BildAsteroid(AsteroidData asteroidData)
    {
        var asteroidModel = new AsteroidModel(asteroidData);
        var asteroidView = asteroidData.AsteroidGO.GetComponent<AsteroidView>();
        var asteroidPresenter = new AsteroidPresenter(asteroidModel, asteroidView);

        return (asteroidModel, asteroidView, asteroidPresenter);
    }

    private AsteroidData GetAsteroidData(AsteroidType asteroidType)
    {
        return Instantiate((int)asteroidType);
    }

    private AsteroidData Instantiate(int index)
    {
        var asteroidData = Object.Instantiate(_asteroidDatas[index]);
        asteroidData.AsteroidGO = Object.Instantiate(_asteroidGameObjekts[index]);
        asteroidData.AsteroidTarget = _targetTransform;

        return asteroidData;
    }
}
