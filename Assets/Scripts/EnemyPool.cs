using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class EnemyPool
{
    private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
    private readonly int _capacityPool;
    private Transform _rootPool;

    public EnemyPool()
    {
        _enemyPool = new Dictionary<string, HashSet<Enemy>>();
        if (!_rootPool)
        {
            _rootPool = new GameObject(NameManager.POOL_CONTENT).transform;
        }
    }
    public Enemy GetEnemy(string type)
    {
        Enemy result;
        result = GetEnemyFromList(GetListEnemies(type));

        return result;
    }
    public void AddObjectPool(string type, Enemy enemy)
    {
        HashSet<Enemy> enemies = GetListEnemies(type);
        ReturnToPool(enemy.transform);
        enemies.Add(enemy);
    }
    private HashSet<Enemy> GetListEnemies(string type)
    {
        return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
    }
    private Enemy GetEnemyFromList(HashSet<Enemy> enemies)
    {
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
