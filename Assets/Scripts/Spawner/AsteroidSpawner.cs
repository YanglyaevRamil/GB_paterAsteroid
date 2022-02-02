using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private const float START_DELAY_ASTEROID = 3.0f;
    private const float SPAWN_INTERVAL_ASTEROID = 0.5f;
    private const float MAX_ANGL_X_RESP_ASTEROID = -20.0f;
    private const float MIN_ANGL_X_RESP_ASTEROID = 20.0f;
    private const int NUM_LAVA_ASTEROID_IN_GRUP = 3;
    private const int NUM_FIRE_ASTEROID_IN_GRUP = 2;
    private const int NUM_ICE_ASTEROID_IN_GRUP = 1;
    private const int NUM_ASTEROID_GRUP = 30;

    public Transform target;

    private AsteroidPresenter asteroidPresenter;
    private AsteroidModel asteroidModel;
    private AsteroidView asteroidView;

    private SceneObjectPool<AsteroidView> asteroidPool;
    private AsteroidDataFactory asteroidDataFactory;

    private void Start()
    {
        
        asteroidPool = new SceneObjectPool<AsteroidView>(NameManager.POOL_CONTENT_ASTEROID);
        asteroidDataFactory = new AsteroidDataFactory();


        for (int i = 0; i < NUM_ASTEROID_GRUP; i++)
        {
            for (int j = 0; j < NUM_LAVA_ASTEROID_IN_GRUP; j++)
            {
                var asteroidLavaData = asteroidDataFactory.InstantiateAsteroidLava();
                asteroidLavaData.AsteroidTarget = target;
                asteroidModel = new AsteroidModel(asteroidLavaData);
                asteroidView = asteroidLavaData.AsteroidGameObject?.GetComponent<AsteroidView>();
                asteroidPresenter = new AsteroidPresenter(asteroidModel, asteroidView);

                asteroidPool.AddObjectPool(asteroidView);
            }
            for (int k = 0; k < NUM_FIRE_ASTEROID_IN_GRUP; k++)
            {
                var asteroidFireData = asteroidDataFactory.InstantiateAsteroidFire();
                asteroidFireData.AsteroidTarget = target;
                asteroidModel = new AsteroidModel(asteroidFireData);
                asteroidView = asteroidFireData.AsteroidGameObject?.GetComponent<AsteroidView>();
                asteroidPresenter = new AsteroidPresenter(asteroidModel, asteroidView);

                asteroidPool.AddObjectPool(asteroidView);
            }
            for (int l = 0; l < NUM_ICE_ASTEROID_IN_GRUP; l++)
            {
                var asteroidIceData = asteroidDataFactory.InstantiateAsteroidIce();
                asteroidIceData.AsteroidTarget = target;
                asteroidModel = new AsteroidModel(asteroidIceData);
                asteroidView = asteroidIceData.AsteroidGameObject?.GetComponent<AsteroidView>();
                asteroidPresenter = new AsteroidPresenter(asteroidModel, asteroidView);

                asteroidPool.AddObjectPool(asteroidView);
            }
        }
        InvokeRepeating("GetAsteroidInPool", START_DELAY_ASTEROID, SPAWN_INTERVAL_ASTEROID);
    }

    private void GetAsteroidInPool()
    {
        float rndX = Random.Range(MIN_ANGL_X_RESP_ASTEROID, MAX_ANGL_X_RESP_ASTEROID);
        var asteroid = asteroidPool.GetObject();
        asteroid.transform.localPosition = target.TransformPoint(rndX, 0 , 300);
        asteroid.gameObject.SetActive(true);
    }
}
