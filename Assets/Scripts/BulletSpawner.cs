using UnityEngine;

public class BulletSpawner : Spawner
{
    public GameObject playerGameObject;
    private Player player;

    private void Start()
    {
        player = playerGameObject.GetComponent<Player>();
    }

    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (player.Shooting)
        {
            Spawn();
        }
    }

    protected override void Spawn()
    {
        var transformShip = player.GetComponent<Transform>();
        Instantiate(objectPrefab, transform.position, transformShip.rotation);
    }
}
