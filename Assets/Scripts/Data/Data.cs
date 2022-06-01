using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data", order = 51)]
public class Data : ScriptableObject
{
    [SerializeField] private string asteroidDataPath;
    [SerializeField] private string gunDataPath;
    [SerializeField] private string bulletDataPath;
    [SerializeField] private string spaceShipDataPath;
    [SerializeField] private string asteroidSpawnerDataPath;
    [SerializeField] private string bulletSpawnerDataPath;
    private AsteroidData[] asteroidData;
    private GunData[] gunData;
    private BulletData[] bulletData;
    private SpaceShipData[] spaceShipData;
    private AsteroidSpawnerData[] asteroidSpawnerData;
    private BulletSpawnerData[] bulletSpawnerData;
    public AsteroidData[] Asteroid
    {
        get
        {
            if (asteroidData == null)
            {
                asteroidData = LoadAll<AsteroidData>("ScriptableObject/" + asteroidDataPath);
            }

            return asteroidData;
        }
    }

    public GunData[] Gun
    {
        get
        {
            if (gunData == null)
            {
                gunData = LoadAll<GunData>("ScriptableObject/" + gunDataPath);
            }

            return gunData;
        }
    }

    public BulletData[] Bullet
    {
        get
        {
            if (bulletData == null)
            {
                bulletData = LoadAll<BulletData>("ScriptableObject/" + bulletDataPath);
            }

            return bulletData;
        }
    }

    public SpaceShipData[] SpaceShip
    {
        get
        {
            if (spaceShipData == null)
            {
                spaceShipData = LoadAll<SpaceShipData>("ScriptableObject/" + spaceShipDataPath);
            }

            return spaceShipData;
        }
    }

    public AsteroidSpawnerData[] AsteroidSpawnerData
    {
        get
        {
            if (asteroidSpawnerData == null)
            {
                asteroidSpawnerData = LoadAll<AsteroidSpawnerData>("ScriptableObject/" + asteroidSpawnerDataPath);
            }

            return asteroidSpawnerData;
        }
    }

    public BulletSpawnerData[] BulletSpawnerData
    {
        get
        {
            if (asteroidSpawnerData == null)
            {
                bulletSpawnerData = LoadAll<BulletSpawnerData>("ScriptableObject/" + bulletSpawnerDataPath);
            }

            return bulletSpawnerData;
        }
    }
    private T[] LoadAll<T>(string resourcesPath) where T : Object =>
        Resources.LoadAll<T>(Path.ChangeExtension(resourcesPath, null));

    private T Load<T>(string resourcesPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
