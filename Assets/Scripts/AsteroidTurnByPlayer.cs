
public class AsteroidTurnByPlayer : ObjectTurnByPlayer
{
    private void OnEnable()
    {
        ship = GetComponentInParent<Asteroid>().ship;
    }
}
