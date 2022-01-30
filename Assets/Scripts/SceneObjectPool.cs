using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneObjectPool<T>
{
    private readonly HashSet<T> _pool = new HashSet<T>();
    private readonly Transform _root;

    public SceneObjectPool(string prefabName)
    {
        _root = new GameObject($"{prefabName}").transform;
    }

    public T GetObject()
    {
        var sceneObject = _pool.FirstOrDefault(a => !(a as MonoBehaviour).gameObject.activeSelf);
        return sceneObject;
    }

    public void AddObjectPool(T sceneObject)
    {
        ReturnToPool((sceneObject as MonoBehaviour).transform);
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
