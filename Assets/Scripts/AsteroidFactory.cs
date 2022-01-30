using UnityEngine;

public class AsteroidFactory
{
    public AsteroidBehaviour Create(float speed, int damage, int health, float radius, int pricePoints, Transform targetTransform)
    {
        AsteroidBehaviour asteroid = Object.Instantiate(Resources.Load<AsteroidBehaviour>("Asteroid/Asteroid_0"));
        asteroid.AsteroidInitParametr(speed, damage, health, radius, pricePoints);
        asteroid.TargetTransform = targetTransform;
        asteroid.name = "Asteroid";
        return asteroid;
    }
}
