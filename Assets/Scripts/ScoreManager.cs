
public class ScoreManager
{
    public int score;
    public ScoreManager()
    {
        score = 0;
        EventAggregator.SpaceObjectDied.Subscribe(OnAsteroidtDied);
    }
    private void OnAsteroidtDied(SpaceObject asteroid)
    {
        if (asteroid is Asteroid)
        {
            score += 1;
        }
    }
}
