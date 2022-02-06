using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMeneger : MonoBehaviour
{
    void Start()
    {
        var playerSpawnerGameObject = new GameObject("PlayerSpawner");
        playerSpawnerGameObject.transform.SetParent(transform);
        var playerSpawner = playerSpawnerGameObject?.AddComponent<PlayerSpawner>();

        var asteroidSpawnerGameObject = new GameObject("AsteroidSpawner");
        asteroidSpawnerGameObject.transform.SetParent(transform);
        var asteroidSpawner = asteroidSpawnerGameObject?.AddComponent<AsteroidSpawner>();
        asteroidSpawner.target = playerSpawner.PlayerObject.transform;
        asteroidSpawner.OnDeadAsteroid += DeadAsteroid;

        var playerUIGameObject = Instantiate(Resources.Load<GameObject>("PrefabsAsset/UI/CanvasUI"));
        var playerUI = playerUIGameObject?.GetComponent<PlayerShipUIManager>();

    }

    private void DeadAsteroid(AsteroidData asteroidData)
    {
        Debug.Log(asteroidData.AsteroidType);
        Debug.Log(asteroidData.PricePoints);
        Debug.Log("******");
    }
}
