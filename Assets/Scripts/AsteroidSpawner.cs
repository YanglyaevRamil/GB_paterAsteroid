using UnityEngine;

public class AsteroidSpawner : Spawner
{
    private const float START_DELAY = 3.0f;
    private const float SPAWN_INTERVAL = 0.5f;
    private const float MAX_X = -20.0f;
    private const float MIN_X = 20.0f;
    private const float MIN_SPEED = 0.1f;
    private const int MIN_DAMAGE = 5;
    private const int MIN_HP = 1;
    private const float MIN_RAD = 0.5f;
    private const int NUMBER_DIFF_ASTEROID = 3;
    private const int NUMBER_ASTEROID_IN_PULL = 50;

    public GameObject shipGameObject;

    private int scaleFactor;
    private float speed;
    private int damage;
    private int health;
    private float radius;

    private float startDelay = START_DELAY;
    private float spawnInterval = SPAWN_INTERVAL;

    private AsteroidFactory asteroidFactory;
    private EnemyPool enemyPool;

    private Asteroid asteroid;
    void Start()
    {
        speed = MIN_SPEED;
        damage = MIN_DAMAGE;
        health = MIN_HP;
        radius = MIN_RAD;
        asteroidFactory = new AsteroidFactory();
        enemyPool = new EnemyPool();

        for (int i = 0; i < NUMBER_ASTEROID_IN_PULL; i++)
        {
            scaleFactor = Random.Range(1, NUMBER_DIFF_ASTEROID);
            asteroid = asteroidFactory.Create(speed * scaleFactor, damage * scaleFactor, health * scaleFactor, radius * scaleFactor);
            asteroid.ship = shipGameObject;
            enemyPool.AddObjectPool("Asteroid", asteroid);
        }

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
