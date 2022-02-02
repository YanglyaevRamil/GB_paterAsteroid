using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMeneger : MonoBehaviour
{
    private GameObject playerSpawnerGameObject;
    private GameObject asteroidSpawnerGameObject;

    void Start()
    {
        var PrefabSpaceShip = Resources.Load<GameObject>("PrefabsAsset/SpaceShip/SpaceShip");
        var playerObject = Instantiate(PrefabSpaceShip, Vector3.zero, Quaternion.identity);

        playerSpawnerGameObject = new GameObject("PlayerSpawner");
        playerSpawnerGameObject.transform.SetParent(transform);
        var playerSpawner = playerSpawnerGameObject?.AddComponent<PlayerSpawner>();
        playerSpawner.playerObject = playerObject;

        asteroidSpawnerGameObject = new GameObject("AsteroidSpawner");
        asteroidSpawnerGameObject.transform.SetParent(transform);
        var asteroidSpawner = asteroidSpawnerGameObject?.AddComponent<AsteroidSpawner>();
        asteroidSpawner.target = playerObject.transform;
    }
}
