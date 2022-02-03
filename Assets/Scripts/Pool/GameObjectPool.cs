using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectPool
{
    private readonly HashSet<GameObject> _pool = new HashSet<GameObject>();
    private readonly Transform _root;

    public GameObjectPool(string prefabName)
    {
        _root = new GameObject($"{prefabName}").transform;
    }

    public GameObject GetObject()
    {
        var sceneObject = _pool.FirstOrDefault(a => !a.gameObject.activeSelf);
        return sceneObject;
    }

    public void AddObjectPool(GameObject sceneObject)
    {
        ReturnToPool(sceneObject.transform);
        _pool.Add(sceneObject);
    }

    private void ReturnToPool(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.gameObject.SetActive(false);
        transform.SetParent(_root);
    }
}
