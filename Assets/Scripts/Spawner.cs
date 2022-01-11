using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    protected List<GameObject> objectPrefabList;
    //[SerializeField] protected Transform spawnPosition;

    protected virtual void Spawn()
    {
        GameObject.Instantiate(objectPrefab, transform.position/*spawnPosition.position*/, Quaternion.identity);
    }
}
