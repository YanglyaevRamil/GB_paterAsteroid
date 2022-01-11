
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    protected List<GameObject> objectPrefabList;
    

    protected virtual void Spawn()
    {
        GameObject.Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
