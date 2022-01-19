using UnityEngine;

public class AsteroidFactory
{
    public Asteroid Create(SpaceStoneMoving spaceStoneMoving, SpaceStoneDead spaceStoneDead, SpaceObjectRotation spaceObjectRotation)
    {
        Asteroid asteroid = Object.Instantiate(Resources.Load<Asteroid>("Asteroid_0"));
        asteroid.AsteroidBuilder(spaceStoneMoving, spaceStoneDead, spaceObjectRotation);
        return asteroid;
    }
    public Asteroid Create(float speed, int damage, int health, float radius, Transform targetTransform)
    {
        Asteroid asteroid = Object.Instantiate(Resources.Load<Asteroid>("Asteroid_0"));
        asteroid.AsteroidInitParametr(speed, damage, health, radius);
        asteroid.TargetTransform = targetTransform;
        return asteroid;
    }
}
