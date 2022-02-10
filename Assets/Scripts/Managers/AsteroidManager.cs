using System;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public Action<AsteroidData> OnDeadAsteroid;
    public Transform target;

    private AsteroidPresenter asteroidPresenter;
    private AsteroidModel asteroidModel;
    private AsteroidView asteroidView;

    private GameObjectPool asteroidPool;
    private AsteroidDataFactory asteroidDataFactory;

    private void Start()
    {
        asteroidPool = new GameObjectPool(NameManager.POOL_CONTENT_ASTEROID);
        asteroidDataFactory = new AsteroidDataFactory(target);

        for (int i = 0; i < AsteroidConst.NUM_ASTEROID_GRUP; i++)
        {
            for (int j = 0; j < AsteroidConst.NUM_LAVA_ASTEROID_IN_GRUP; j++)
            {
                var asteroidData = asteroidDataFactory.InstantiateAsteroid(AsteroidType.Lava);

                DeploymentAsteroidData(asteroidData);
            }
            for (int k = 0; k < AsteroidConst.NUM_FIRE_ASTEROID_IN_GRUP; k++)
            {
                var asteroidData = asteroidDataFactory.InstantiateAsteroid(AsteroidType.Fire);

                DeploymentAsteroidData(asteroidData);
            }
            for (int l = 0; l < AsteroidConst.NUM_ICE_ASTEROID_IN_GRUP; l++)
            {
                var asteroidData = asteroidDataFactory.InstantiateAsteroid(AsteroidType.Ice);

                DeploymentAsteroidData(asteroidData);
            }
        }
        InvokeRepeating("GetAsteroidInPool", AsteroidConst.START_DELAY_ASTEROID, AsteroidConst.SPAWN_INTERVAL_ASTEROID);
    }

    private void DeadAsteroid(AsteroidData asteroidData)
    {
        OnDeadAsteroid?.Invoke(asteroidData);
    }

    private void DeploymentAsteroidData(AsteroidData asteroidData)
    {
        var asteroidGameObject = asteroidData.AsteroidGameObject;
        asteroidPool.AddObjectPool(asteroidGameObject);
        asteroidView = asteroidGameObject?.GetComponent<AsteroidView>();
        asteroidModel = new AsteroidModel(asteroidData);
        asteroidPresenter = new AsteroidPresenter(asteroidModel, asteroidView);
        asteroidPresenter.OnDeadAsteroid += DeadAsteroid;
    }

    private void GetAsteroidInPool()
    {
        float rndX = UnityEngine.Random.Range(AsteroidConst.MIN_ANGL_X_RESP_ASTEROID, AsteroidConst.MAX_ANGL_X_RESP_ASTEROID);
        var asteroid = asteroidPool.GetObject();
        asteroid.transform.localPosition = target.TransformPoint(rndX, 0 , 300);
        asteroid.SetActive(true);
        SetChildrenActiveState(asteroid.transform, true);
    }
    private void SetChildrenActiveState(Transform gameObjectTransform, bool active)
    {
        foreach (Transform child in gameObjectTransform)
        {
            child.gameObject.SetActive(active);
        }
    }
}
