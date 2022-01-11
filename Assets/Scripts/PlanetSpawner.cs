using UnityEngine;

public class PlanetSpawner : Spawner
{
    protected override void Spawn()
    {
        GameObject.Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
