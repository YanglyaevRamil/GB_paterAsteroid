using UnityEngine;

public class AsteroidSpawner : Spawner
{
    private const float START_DELAY = 3.0f;
    private const float SPAWN_INTERVAL = 0.5f;
    private const float MAX_X = -20.0f;
    private const float MIN_X = 20.0f;
    private const float MIN_SPEED = 0.2f;
    private const int MIN_DAMAGE = 5;
    private const int MIN_HP = 1;
    private const float MIN_RAD = 0.5f;
    private const int NUMBER_DIFF_ASTEROID = 3;
    private const int NUMBER_ASTEROID_IN_PULL = 50;
    private const float ARMOR = 0.2f;
    public GameObject shipGameObject;

    private int scaleFactor;
    private float speed;
    private int damage;
    private int health;
    private float armor;
    private float radius;

    private float startDelay = START_DELAY;
    private float spawnInterval = SPAWN_INTERVAL;

    private SpaceShipEnemyFactory spaceShipEnemyFactory;
    private AsteroidFactory asteroidFactory;
    private EnemyPool enemyPool;

    private Asteroid asteroid;
    private SpaceShipEnemy spaceShipEnemy;
    void Start()
    {
        speed = MIN_SPEED;
        damage = MIN_DAMAGE;
        health = MIN_HP;
        radius = MIN_RAD;
        armor = ARMOR;
        asteroidFactory = new AsteroidFactory();
        spaceShipEnemyFactory = new SpaceShipEnemyFactory();
        enemyPool = new EnemyPool();
        for (int i = 0; i < NUMBER_ASTEROID_IN_PULL; i++)
        {
            scaleFactor = Random.Range(1, NUMBER_DIFF_ASTEROID);
            asteroid = asteroidFactory.Create(speed * scaleFactor, damage * scaleFactor, health * scaleFactor, radius * scaleFactor, shipGameObject.transform);
            enemyPool.AddObjectPool("Asteroid", asteroid);
        }
        for (int i = 0; i < 3; i++)
        {
            spaceShipEnemy = spaceShipEnemyFactory.Create(speed, damage, health, armor, shipGameObject.transform);
            enemyPool.AddObjectPool("SpaceShipEnemy", spaceShipEnemy);
        }
        InvokeRepeating("SpawnAsteroid", startDelay, spawnInterval);
        SpawnSpaceShipEnemy();
    }
    protected void SpawnAsteroid()
    {
        float rndX = Random.Range(MAX_X, MIN_X);
        var enemy = enemyPool.GetEnemy("Asteroid");
        enemy.transform.position = transform.TransformPoint(rndX, 0, 0);
        enemy.gameObject.SetActive(true);
    }
    protected void SpawnSpaceShipEnemy()
    {
        float rndX = Random.Range(MAX_X, MIN_X);
        var enemy = enemyPool.GetEnemy("SpaceShipEnemy");
        enemy.transform.position = transform.TransformPoint(rndX, 0, 0);
        enemy.gameObject.SetActive(true);
    }
}
