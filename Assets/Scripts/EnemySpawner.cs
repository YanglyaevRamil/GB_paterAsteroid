using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float START_DELAY_ASTEROID = 3.0f;
    private const float SPAWN_INTERVAL_ASTEROID = 0.5f;
    private const float MAX_ANGL_X_RESP_ASTEROID = -20.0f;
    private const float MIN_ANGL_X_RESP_ASTEROID = 20.0f;
    private const float MIN_SPEED_ASTEROID = 0.2f;
    private const int MIN_DAMAGE_ASTEROID = 5;
    private const int MIN_HP_ASTEROID = 5;
    private const float MIN_RADIUS_ASTEROID = 0.5f;
    private const int NUMBER_DIFF_ASTEROID = 3;
    private const int NUMBER_ASTEROID_IN_PULL = 50;

    private const float MIN_SPEED_SHIP_ENEMY = 0.5f;
    private const int MIN_DAMAGE_SHIP_ENEMY = 10;
    private const int MIN_HP_SHIP_ENEMY = 100;
    private const float MAX_ANGL_X_RESP_SHIP_ENEMY = -20.0f;
    private const float MIN_ANGL_X_RESP_SHIP_ENEMY = 20.0f;
    private const int ARMOR_SHIP_ENEMY = 1;
    private const int NUMBER_SHIP_ENEMY_IN_PULL = 3;

    public GameObject shipGameObject;

    private int scaleFactorAsteroid;
    private float speedAsteroid;
    private int damageAsteroid;
    private int healthAsteroid;
    private float radiusAsteroid;

    private int scaleFactorShipEnemy;
    private float speedShipEnemy;
    private int damageShipEnemy;
    private int healthShipEnemy;
    private int armorShipEnemy;

    private float startDelayAsteroid = START_DELAY_ASTEROID;
    private float spawnIntervalAsteroid = SPAWN_INTERVAL_ASTEROID;

    private SpaceShipEnemyFactory spaceShipEnemyFactory;
    private AsteroidFactory asteroidFactory;
    private EnemyPool enemyPool;

    private Asteroid asteroid;
    private SpaceShipEnemy spaceShipEnemy;
    void Start()
    {
        speedAsteroid = MIN_SPEED_ASTEROID;
        damageAsteroid = MIN_DAMAGE_ASTEROID;
        healthAsteroid = MIN_HP_ASTEROID;
        radiusAsteroid = MIN_RADIUS_ASTEROID;

        speedShipEnemy = MIN_SPEED_SHIP_ENEMY;
        damageShipEnemy = MIN_DAMAGE_SHIP_ENEMY;
        healthShipEnemy = MIN_HP_SHIP_ENEMY;
        armorShipEnemy = ARMOR_SHIP_ENEMY;

        asteroidFactory = new AsteroidFactory();
        spaceShipEnemyFactory = new SpaceShipEnemyFactory();
        enemyPool = new EnemyPool();
        for (int i = 0; i < NUMBER_ASTEROID_IN_PULL; i++)
        {
            scaleFactorAsteroid = Random.Range(1, NUMBER_DIFF_ASTEROID);
            asteroid = asteroidFactory.Create(
                speedAsteroid * scaleFactorAsteroid, 
                damageAsteroid * scaleFactorAsteroid,
                healthAsteroid * scaleFactorAsteroid, 
                radiusAsteroid * scaleFactorAsteroid, 
                shipGameObject.transform);
            enemyPool.AddObjectPool("Asteroid", asteroid);
        }
        for (int i = 0; i < NUMBER_SHIP_ENEMY_IN_PULL; i++)
        {
            spaceShipEnemy = spaceShipEnemyFactory.Create(speedShipEnemy, damageShipEnemy, healthShipEnemy, armorShipEnemy, shipGameObject.transform);
            enemyPool.AddObjectPool("SpaceShipEnemy", spaceShipEnemy);
        }
        InvokeRepeating("SpawnAsteroid", startDelayAsteroid, spawnIntervalAsteroid);
        SpawnSpaceShipEnemy();
    }
    protected void SpawnAsteroid()
    {
        float rndX = Random.Range(MIN_ANGL_X_RESP_ASTEROID, MAX_ANGL_X_RESP_ASTEROID);
        var enemy = enemyPool.GetEnemy("Asteroid");
        enemy.transform.position = transform.TransformPoint(rndX, 0, 0);
        enemy.gameObject.SetActive(true);
    }
    protected void SpawnSpaceShipEnemy()
    {
        float rndX = Random.Range(MIN_ANGL_X_RESP_SHIP_ENEMY, MAX_ANGL_X_RESP_SHIP_ENEMY);
        var enemy = enemyPool.GetEnemy("SpaceShipEnemy");
        enemy.transform.position = transform.TransformPoint(rndX, 0, 0);
        enemy.gameObject.SetActive(true);
    }
}
