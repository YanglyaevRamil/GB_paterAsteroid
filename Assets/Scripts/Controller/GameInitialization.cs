using UnityEngine;

internal sealed class GameInitialization
{
    public GameInitialization(Controllers controllers, Data data)
    {
        var userInputModel = new UserInputModel();

        var bulletFactory = new BulletFactory(data.Bullet);
        var bulletSpawnerFactory = new BulletSpawnerFactory(data.BulletSpawnerData, bulletFactory);
        var bulletSpawner = bulletSpawnerFactory.GetBulletSpawner(BulletSpawnerType.DefaultBulletSpawner, BulletType.DefaultBullet);

        var gunFactory = new GunFactory(data.Gun, bulletSpawner.bulletSpawnerModel);
        var gun = gunFactory.GetGun(GunType.DefaultGun);

        var spaceShipFactory = new SpaceShipFactory(data.SpaceShip, userInputModel, gun.gunModel);
        var spaceShip = spaceShipFactory.GetSpaceShip(SpaceShipType.DefaultSpaceShip);
        
        var asteroidFactory = new AsteroidFactory(data.Asteroid, spaceShip.spaceShipView.transform);
        var asteroidSpawnerFactory = new AsteroidSpawnerFactory(data.AsteroidSpawnerData, asteroidFactory);

        var asteroidSpawner = asteroidSpawnerFactory.GetAsteroidSpawner(AsteroidSpawnerType.DefaultAsteroidSpawner);


        controllers.Add(userInputModel);
        controllers.Add(asteroidSpawner.asteroidSpawnerModel);
        controllers.Add(bulletSpawner.bulletSpawnerModel);
    }
}
