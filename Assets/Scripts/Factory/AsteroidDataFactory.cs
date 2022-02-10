using UnityEngine;

public class AsteroidDataFactory
{
    private AsteroidData[] asteroidDatas;
    private GameObject[] asteroidGameObjekts;
    private Transform targetTransform;

    public AsteroidDataFactory()
    {
        asteroidDatas = Resources.LoadAll<AsteroidData>("ScriptableObject/Asteroid");
        asteroidGameObjekts = Resources.LoadAll<GameObject>("PrefabsAsset/Asteroid");
    }

    public AsteroidDataFactory(Transform targetTransform)
    {
        asteroidDatas = Resources.LoadAll<AsteroidData>("ScriptableObject/Asteroid");
        asteroidGameObjekts = Resources.LoadAll<GameObject>("PrefabsAsset/Asteroid");
        this.targetTransform = targetTransform;
    }

    public AsteroidData InstantiateAsteroid(AsteroidType asteroidType)
    {
        switch (asteroidType)
        {
            case AsteroidType.Lava :
                return Instantiate(0);

            case AsteroidType.Fire :
                return Instantiate(1);

            case AsteroidType.Ice :
                return Instantiate(2);

            default :
                return Instantiate(0);
        }
    }

    private AsteroidData Instantiate(int index)
    {
        var asteroidData = Object.Instantiate(asteroidDatas[index]);

        asteroidData.AsteroidGameObject = Object.Instantiate(asteroidGameObjekts[index]);

        asteroidData.AsteroidTarget = targetTransform;

        return asteroidData;
    }
}
