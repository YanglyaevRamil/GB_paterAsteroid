using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


public sealed class EnemyPool
{
    private readonly Dictionary<string, HashSet<Asteroid>> _enemyPool;
    private readonly int _capacityPool;
    private Transform _rootPool;

    public EnemyPool()
    {
        _enemyPool = new Dictionary<string, HashSet<Asteroid>>();
        if (!_rootPool)
        {
            _rootPool = new GameObject(NameManager.POOL_CONTENT).transform;
        }
    }

    public Asteroid GetEnemy(string type)
    {
        Asteroid result;
        result = GetAsteroid(GetListEnemies(type));

        return result;
    }

    private HashSet<Asteroid> GetListEnemies(string type)
    {
        return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Asteroid>();
    }
    public void AddObjectPool(string type, Asteroid asteroid)
    {
        HashSet<Asteroid> enemies = GetListEnemies(type);
        var instantiate = Object.Instantiate(asteroid);
        ReturnToPool(instantiate.transform);
        enemies.Add(instantiate);
    }
    private Asteroid GetAsteroid(HashSet<Asteroid> enemies)
    {
        //var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        //if (enemy == null)
        //{
        //    for (var i = 0; i < _capacityPool; i++)
        //    {
        //        var instantiate = Object.Instantiate(asteroid);
        //        ReturnToPool(instantiate.transform);
        //        enemies.Add(instantiate);
        //    }
        //
        //    GetAsteroid(enemies);
        //}
        var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        return enemy;
    }

    private void ReturnToPool(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.gameObject.SetActive(false);
        transform.SetParent(_rootPool);
    }

    public void RemovePool()
    {
        Object.Destroy(_rootPool.gameObject);
    }
}
