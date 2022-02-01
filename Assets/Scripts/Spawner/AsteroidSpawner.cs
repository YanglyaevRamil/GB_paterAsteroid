using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private const float SPEED_ASTEROID = 0.5f;
    private const int HEALTH_ASTEROID = 100;
    private const float ROTATESPEED_ASTEROID = 1.0f;
    private const int SPACE_SHIP_DAMAG_ASTEROID = 5;

    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private float rotatesSpeed;
    [SerializeField] private int asteroidDamag;

    public Transform target;

    private Quaternion rotates;

    private AsteroidPresenter asteroidPresenter;
    private AsteroidModel asteroidModel;
    private AsteroidView asteroidView;

    private SceneObjectPool<GameObject> asteroidPool;
    private AsteroidObjectFactory asteroidObjectFactory = new AsteroidObjectFactory();
    private AsteroidModelFactory asteroidModelFactory = new AsteroidModelFactory();
    public void Start()
    {
        var asteroidObject = asteroidObjectFactory.CreateAsteroidLava();
        asteroidView = asteroidObject?.GetComponent<AsteroidView>();
        var meshRenderer = asteroidObject?.GetComponent<MeshRenderer>();
        var sphereCollider = asteroidObject?.GetComponent<SphereCollider>();

        asteroidModel = asteroidModelFactory.Create(
            health, 
            asteroidObject.transform, 
            speed, rotates, 
            target, 
            meshRenderer, 
            sphereCollider);

        asteroidPresenter = new AsteroidPresenter(asteroidModel, asteroidView);


        //asteroidModelFactory

        // var asteroidObject = Instantiate(asteroidPrefab);

        //       GameObject StarShipWeaponRight = playerObject.transform.Find("StarShipModel/StarShipWeaponRight/BulletSpawnerRight").gameObject;
        //       GameObject StarShipWeaponLeft = playerObject.transform.Find("StarShipModel/StarShipWeaponLeft/BulletSpawnerLeft").gameObject;
        //       BulletSpawner bulletSpawnerRight = StarShipWeaponRight.AddComponent<BulletSpawner>();
        //       BulletSpawner bulletSpawnerLeft = StarShipWeaponLeft.AddComponent<BulletSpawner>();
        //
        //       playerView = playerObject.GetComponent<PlayerView>();
        //       playerModel = new PlayerModel(
        //           new SpaceShip(health, playerObject.transform, speed, rotatesLeftY, rotatesRightY, spaceShipDamag), 
        //           new SpaceShipGun(ammunition, gunRecoilTime, gunReloadingTime));
        //
        //       playerPresenter = new PlayerPresenter(playerModel, playerView);
        //
        //       playerPresenter.OnPlayerShooting += bulletSpawnerRight.Shoot;
        //       playerPresenter.OnPlayerShooting += bulletSpawnerLeft.Shoot;
    }
}
