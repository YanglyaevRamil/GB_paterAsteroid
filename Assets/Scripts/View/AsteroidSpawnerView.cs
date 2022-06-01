using System;
using System.Collections;
using UnityEngine;

public class AsteroidSpawnerView : MonoBehaviour
{
    public event Action OnSpawn;

    private void OnEnable()
    {
        StartCoroutine(CountToSpawn());
    }

    private IEnumerator CountToSpawn()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(AsteroidSpawnerConst.SPAWN_INTERVAL_ASTEROID);
            OnSpawn.Invoke();
        }
    }

    private void OnDisable()
    {
        StopCoroutine(CountToSpawn());
    }
}
