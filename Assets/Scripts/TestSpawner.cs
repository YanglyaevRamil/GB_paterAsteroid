using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB_starship.ObjectPool;

public class TestSpawner : MonoBehaviour
{
    private const float MAX_X = -20.0f;
    private const float MIN_X = 20.0f;
    public GameObject shipGameObject;

    void Start()
    {
        
        EnemyPool enemyPool = new EnemyPool(5);
        var enemy = enemyPool.GetEnemy("Asteroid");
        enemy.GetComponent<Asteroid>().ship = shipGameObject;
        float rndX = Random.Range(MAX_X, MIN_X);
        enemy.transform.position = transform.TransformPoint(rndX, 0, 0);
        enemy.gameObject.SetActive(true);
        
    }

    
    
}
