using UnityEngine;

public class AsteroidSpawner : Spawner
{
    private const float START_DELAY = 3.0f;
    private const float SPAWN_INTERVAL = 0.5f;
    private const float MAX_X = -20.0f;
    private const float MIN_X = 20.0f;

    public GameObject shipGameObject;

    private float startDelay = START_DELAY;
    private float spawnInterval = SPAWN_INTERVAL;
    void Start()
    {
        (objectPrefab.GetComponent<Asteroid>()).ship = shipGameObject;
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    protected override void Spawn()
    {
        float rndX = Random.Range(MAX_X, MIN_X);
        Vector3 thePosition = transform.TransformPoint(rndX, 0, 0);

        Instantiate(objectPrefab, thePosition, Quaternion.identity);
    }
}
