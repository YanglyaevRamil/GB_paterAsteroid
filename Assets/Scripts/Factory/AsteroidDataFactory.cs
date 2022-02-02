using UnityEngine;

public class AsteroidDataFactory
{
    private AsteroidData[] asteroidDatas;
    private GameObject[] asteroidGameObjekts;

    public AsteroidDataFactory()
    {
        asteroidDatas = Resources.LoadAll<AsteroidData>("ScriptableObject/Asteroid");
        asteroidGameObjekts = Resources.LoadAll<GameObject>("PrefabsAsset/Asteroid");
    }

    public AsteroidData InstantiateAsteroidLava()
    {
        var asteroidData = Object.Instantiate(asteroidDatas[0]);

        asteroidData.AsteroidGameObject = Object.Instantiate(asteroidGameObjekts[0]);

        return asteroidData;
    }

    public AsteroidData InstantiateAsteroidFire()
    {
        var asteroidData = Object.Instantiate(asteroidDatas[1]);

        asteroidData.AsteroidGameObject = Object.Instantiate(asteroidGameObjekts[1]);

        return asteroidData;
    }

    public AsteroidData InstantiateAsteroidIce()
    {
        var asteroidData = Object.Instantiate(asteroidDatas[2]);

        asteroidData.AsteroidGameObject = Object.Instantiate(asteroidGameObjekts[2]);
        
        return asteroidData;
    }

}
