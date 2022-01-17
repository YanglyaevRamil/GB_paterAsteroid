using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    internal sealed class ViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache
            = new Dictionary<string, ObjectPool>(12);

        public void Instantiate(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            viewPool.Pop();
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}
