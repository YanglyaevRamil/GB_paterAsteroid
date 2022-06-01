using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //private GameObject playerObject;
    //private SpaceShipDataFactory spaceShipDataFactory;
    //private GunDataFactory gunDataFactory;
    //private SpaceShipData spaceShipData;
    //private GunData gunData;
    //private BulletSpawner bulletSpawnerRight;
    //private BulletSpawner bulletSpawnerLeft;
    //
    //public Action<int> OnPlayerDamageTaken;
    //public Action<int> OnPlayerShooting;
    //public Action<int> OnPlayerReloadGun;
    //
    //public GameObject PlayerObject { get { return playerObject; } }
    //public SpaceShipData SpaceShipData { get { return spaceShipData; } }
    //public GunData GunData { get { return gunData; } }

  //  private void Awake()
  //  {
  //      spaceShipDataFactory = new SpaceShipDataFactory();
  //      gunDataFactory = new GunDataFactory();
  //
  //      spaceShipData = spaceShipDataFactory.GetShipData(SpaceShipType.DefaultSpaceShip);
  //      gunData = gunDataFactory.InstantiateGun(GunType.DefaultGun);
  //
  //      playerObject = spaceShipData.SpaceShipGO;
  //      var playerObjectRB = playerObject?.GetComponent<Rigidbody>();
  //
  //      GameObject StarShipWeaponRight = playerObject.transform.Find("StarShipModel/StarShipWeaponRight/BulletSpawnerRight").gameObject;
  //      GameObject StarShipWeaponLeft = playerObject.transform.Find("StarShipModel/StarShipWeaponLeft/BulletSpawnerLeft").gameObject;
  //
  //      bulletSpawnerRight = StarShipWeaponRight.AddComponent<BulletSpawner>();
  //      bulletSpawnerLeft = StarShipWeaponLeft.AddComponent<BulletSpawner>();
  //
  //      playerView = playerObject.GetComponent<PlayerView>();
  //      playerModel = new PlayerModel(spaceShipData, gunData);
  //      playerPresenter = new PlayerPresenter(playerModel, playerView);
  //
  //      playerPresenter.OnPlayerShooting += PlayerShooting;
  //      playerPresenter.OnDamageTaken += DamageTaken;
  //      playerPresenter.OnReloadGun += ReloadGun;
  //  }
  //
  //  private void ReloadGun(int info)
  //  {
  //      OnPlayerReloadGun?.Invoke(info);
  //  }
  //
  //  private void PlayerShooting(int info)
  //  {
  //      bulletSpawnerRight.Shoot();
  //      bulletSpawnerLeft.Shoot();
  //      OnPlayerShooting?.Invoke(info);
  //  }
  //
  //  private void DamageTaken(int info)
  //  {
  //      OnPlayerDamageTaken?.Invoke(info);
  //  }
}
