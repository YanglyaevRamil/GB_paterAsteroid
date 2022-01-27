using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal sealed class BulletPool
{
    private readonly HashSet<BulletBehaviour> _pool= new HashSet<BulletBehaviour>();
    private readonly BulletBehaviour _prefab;
    private readonly Transform _root;

    public BulletPool(BulletBehaviour prefab)
    {
        _prefab = prefab;
        _root = new GameObject($"[{_prefab.name}]").transform;
    }
    public BulletBehaviour GetObject()
    {
        var bullet = _pool.FirstOrDefault(a => !a.gameObject.activeSelf);
        return bullet;
    }
    public void AddObjectPool(BulletBehaviour bullet)
    {
        ReturnToPool(bullet.transform);
        _pool.Add(bullet);
    }
    private void ReturnToPool(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.gameObject.SetActive(false);
        transform.SetParent(_root);
    }
}
