using System;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerModel : IFixedExecute
{
    public Action<IPointsProvider> OnDeadAsteroid = delegate (IPointsProvider pp) {  };

    private SceneObjectPool<AsteroidView> _asteroidPool;
    private List<AsteroidModel> _asteroidModels; 
    public AsteroidSpawnerModel(AsteroidSpawnerData asteroidSpawnerData, AsteroidFactory asteroidFactory)
    {
        _asteroidModels = new List<AsteroidModel>();

        _asteroidPool = new SceneObjectPool<AsteroidView>(NameManager.POOL_CONTENT_ASTEROID);

        for (int i = 0; i < asteroidSpawnerData.NumAsteroidInGrup; i++)
        {
            for (int j = 0; j < asteroidSpawnerData.NumLavaAsteroidInGrup; j++)
            {
                var asteroid = asteroidFactory.GetAsteroid(AsteroidType.Lava);
                _asteroidModels.Add(asteroid.asteroidModel);
                _asteroidPool.AddObjectPool(asteroid.asteroidView);

            }
            for (int k = 0; k < asteroidSpawnerData.NumFireAsteroidInGrup; k++)
            {
                var asteroid = asteroidFactory.GetAsteroid(AsteroidType.Fire);
                _asteroidModels.Add(asteroid.asteroidModel);
                _asteroidPool.AddObjectPool(asteroid.asteroidView);

            }
            for (int l = 0; l < asteroidSpawnerData.NumIceAsteroidInGrup; l++)
            {
                var asteroid = asteroidFactory.GetAsteroid(AsteroidType.Ice);
                _asteroidModels.Add(asteroid.asteroidModel);
                _asteroidPool.AddObjectPool(asteroid.asteroidView);
            }
        }

        foreach (var item in _asteroidModels)
        {
            item.OnDead += DeadAsteroidEvent;
        }
    }

    ~AsteroidSpawnerModel()
    {
        foreach (var item in _asteroidModels)
        {
            item.OnDead -= DeadAsteroidEvent;
        }
    }

    public void FixedExecute()
    {
        for (int i = 0; i < _asteroidModels.Count; i++)
        {
            _asteroidModels[i].FixedExecute();
        }
    }

    public void GetAsteroidFromPool()
    {
        var asteroid = _asteroidPool.GetObject();
        asteroid.gameObject.SetActive(true);
        SetChildrenActiveState(asteroid.transform, true);
    }

    private void SetChildrenActiveState(Transform gameObjectTransform, bool active)
    {
        foreach (Transform child in gameObjectTransform)
        {
            child.gameObject.SetActive(active);
        }
    }

    private void DeadAsteroidEvent(IPointsProvider pointsProvider)
    {
        OnDeadAsteroid.Invoke(pointsProvider);
    }
}
