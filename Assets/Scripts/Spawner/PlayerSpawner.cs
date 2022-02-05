using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private PlayerPresenter playerPresenter;
    private PlayerModel playerModel;
    private PlayerView playerView;

    public GameObject PlayerObject { get { return playerObject; } }
    private GameObject playerObject;

    private SpaceShipDataFactory spaceShipDataFactory;
    private GunDataFactory gunDataFactory;

    private void Awake()
    {
        spaceShipDataFactory = new SpaceShipDataFactory();
        gunDataFactory = new GunDataFactory();

        var spaceShipData = spaceShipDataFactory.InstantiateSpaceShip(SpaceShipType.DefaultSpaceShip);
        var gunData = gunDataFactory.InstantiateGun(GunType.DefaultGun);

        playerObject = spaceShipData.SpaceShipGameObject;
        var playerObjectRB = playerObject?.GetComponent<Rigidbody>();

        GameObject StarShipWeaponRight = playerObject.transform.Find("StarShipModel/StarShipWeaponRight/BulletSpawnerRight").gameObject;
        GameObject StarShipWeaponLeft = playerObject.transform.Find("StarShipModel/StarShipWeaponLeft/BulletSpawnerLeft").gameObject;

        BulletSpawner bulletSpawnerRight = StarShipWeaponRight.AddComponent<BulletSpawner>();
        BulletSpawner bulletSpawnerLeft = StarShipWeaponLeft.AddComponent<BulletSpawner>();

        playerView = playerObject.GetComponent<PlayerView>();
        playerModel = new PlayerModel(
            new SpaceShip(
                spaceShipData.Health,
                playerObject.transform,
                spaceShipData.Speed,
                spaceShipData.RotationSpeed,
                spaceShipData.Damage,
                playerObjectRB),

            new SpaceShipGun(
                gunData.Ammunition,
                gunData.GunRecoilTime,
                gunData.GunReloadingTime));

        playerPresenter = new PlayerPresenter(playerModel, playerView);

        playerPresenter.OnPlayerShooting += bulletSpawnerRight.Shoot;
        playerPresenter.OnPlayerShooting += bulletSpawnerLeft.Shoot;
    }
}
