using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal sealed class BulletPool
{
    private readonly HashSet<Bullet> _pool= new HashSet<Bullet>();
    private readonly Bullet _prefab;
    private readonly Transform _root;

    public BulletPool(Bullet prefab)
    {
        _prefab = prefab;
        _root = new GameObject($"[{_prefab.name}]").transform;
    }
    public Bullet GetObject()
    {
        var bullet = _pool.FirstOrDefault(a => !a.gameObject.activeSelf);
        return bullet;
    }
    public void AddObjectPool(Bullet bullet)
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
