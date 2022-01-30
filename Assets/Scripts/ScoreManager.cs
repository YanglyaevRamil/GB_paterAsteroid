using UnityEngine;
public class ScoreManager
{
    public int score;
    public ScoreManager()
    {
        score = 0;
        AsteroidBehaviour.onAsteroidDead += OnAsteroidtDied;
        SpaceShipEnemyBehaviour.onShipEnemyDead += OnAsteroidtDied;
    }

    private void OnAsteroidtDied(IPricePoints obj)
    {
        score += obj.PricePoints;
    }
}
