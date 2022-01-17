using UnityEngine;

public class AsteroidSpawner : Spawner
{
    private const float START_DELAY = 3.0f;
    private const float SPAWN_INTERVAL = 0.5f;
    private const float MAX_X = -20.0f;
    private const float MIN_X = 20.0f;
    private const float MIN_SPEED = 0.1f;
    private const float MAX_SPEED = 0.3f;
    private const int MIN_DAMAGE = 5;
    private const int MAX_DAMAGE = 15;
    private const int MIN_HP = 1;
    private const int MAX_HP = 3;

    public GameObject shipGameObject;

    private int scaleFactor;
    private float speed;
    private int damage;
    private int health;

    private float startDelay = START_DELAY;
    private float spawnInterval = SPAWN_INTERVAL;

    private AsteroidFactory asteroidFactory;
    private EnemyPool enemyPool;

    private Asteroid asteroid;
    void Start()
    {
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        scaleFactor = Random.Range(1, 3);
        damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE);
        health = Random.Range(MIN_HP, MAX_HP);

        asteroidFactory = new AsteroidFactory();
        asteroid = asteroidFactory.Create(speed, damage, health);
        asteroid.ship = shipGameObject;

        enemyPool = new EnemyPool(50, asteroid);
        enemyPool.GetEnemy("Asteroid");

        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    protected override void Spawn()
    {
        float rndX = Random.Range(MAX_X, MIN_X);
        var enemy = enemyPool.GetEnemy("Asteroid");
        enemy.transform.position = transform.TransformPoint(rndX, 0, 0);
        enemy.gameObject.SetActive(true);
    }
}
