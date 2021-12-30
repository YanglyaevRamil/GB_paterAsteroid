using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject objectPrefab;
    [SerializeField] protected Transform spawnPosition;

    protected virtual void Spawn()
    {
        GameObject.Instantiate(objectPrefab, spawnPosition.position, Quaternion.identity);

    }
}
