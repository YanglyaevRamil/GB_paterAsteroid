using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GB_starship.ObjectPool
{
    public sealed class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Asteroid>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;


        public EnemyPool(int capacityPool)
        {
            _enemyPool = new Dictionary<string, HashSet<Asteroid>>();
            _capacityPool = capacityPool;
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

        private Asteroid GetAsteroid(HashSet<Asteroid> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                var obj = Resources.Load<Asteroid>("Asteroid_0");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(obj);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
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
}
