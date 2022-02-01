using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private const float SPEED_PLAYER = 0.5f;
    private const int HEALTH_PLAYER = 100;
    private const int AMMUNITION_PLAYER = 20;
    private const float GUN_RECOIL_TIME_PLAYER = 0.1f;
    private const float GUN_RELOADING_TIME_PLAYER = 3.0f;
    private const float ROTATESPEED_PLAYER = 3.0f;
    private const int SPACE_SHIP_DAMAG_PLAYER = 200;

    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int ammunition;
    [SerializeField] private float gunRecoilTime;
    [SerializeField] private float gunReloadingTime;
    [SerializeField] private float rotatesSpeedRightY;
    [SerializeField] private float rotatesSpeedLeftY;
    private int spaceShipDamag;

    private Quaternion rotatesRightY, rotatesLeftY;

    public GameObject playerPrefab;

    private PlayerPresenter playerPresenter;
    private PlayerModel playerModel;
    private PlayerView playerView;

    public void Start()
    {
        speed = SPEED_PLAYER;
        health = HEALTH_PLAYER;
        ammunition = AMMUNITION_PLAYER;
        gunRecoilTime = GUN_RECOIL_TIME_PLAYER;
        gunReloadingTime = GUN_RELOADING_TIME_PLAYER;
        spaceShipDamag = SPACE_SHIP_DAMAG_PLAYER;

        rotatesSpeedRightY = ROTATESPEED_PLAYER;
        rotatesRightY = Quaternion.AngleAxis(rotatesSpeedRightY, Vector3.up);
        rotatesSpeedLeftY = -ROTATESPEED_PLAYER;
        rotatesLeftY = Quaternion.AngleAxis(rotatesSpeedLeftY, Vector3.up);

        var playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        GameObject StarShipWeaponRight = playerObject.transform.Find("StarShipModel/StarShipWeaponRight/BulletSpawnerRight").gameObject;
        GameObject StarShipWeaponLeft = playerObject.transform.Find("StarShipModel/StarShipWeaponLeft/BulletSpawnerLeft").gameObject;
        BulletSpawner bulletSpawnerRight = StarShipWeaponRight.AddComponent<BulletSpawner>();
        BulletSpawner bulletSpawnerLeft = StarShipWeaponLeft.AddComponent<BulletSpawner>();
        playerView = playerObject.GetComponent<PlayerView>();
        playerModel = new PlayerModel(
            new SpaceShip(health, playerObject.transform, speed, rotatesLeftY, rotatesRightY, spaceShipDamag), 
            new SpaceShipGun(ammunition, gunRecoilTime, gunReloadingTime));

        playerPresenter = new PlayerPresenter(playerModel, playerView);

        playerPresenter.OnPlayerShooting += bulletSpawnerRight.Shoot;
        playerPresenter.OnPlayerShooting += bulletSpawnerLeft.Shoot;
    }
}
