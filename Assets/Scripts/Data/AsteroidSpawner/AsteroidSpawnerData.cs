using UnityEngine;

[CreateAssetMenu(fileName = "New AsteroidSpawnerData", menuName = "Asteroid Spawner Data", order = 51)]
public class AsteroidSpawnerData : ScriptableObject
{
    [SerializeField]
    private float timerTick;

    [SerializeField]
    private float spawnIntervalAsteroid;

    [SerializeField]
    private int numAsteroidInGrup;

    [SerializeField]
    private int numLavaAsteroidInGrup;

    [SerializeField]
    private int numFireAsteroidInGrup;

    [SerializeField]
    private int numIceAsteroidInGrup;

    public float TimerTick { get { return timerTick; } }
    public float SpawnIntervalAsteroid { get { return spawnIntervalAsteroid; } }
    public int NumAsteroidInGrup { get { return numAsteroidInGrup; } }
    public int NumLavaAsteroidInGrup { get { return numLavaAsteroidInGrup; } }
    public int NumFireAsteroidInGrup { get { return numFireAsteroidInGrup; } }
    public int NumIceAsteroidInGrup { get { return numIceAsteroidInGrup; } }
}
