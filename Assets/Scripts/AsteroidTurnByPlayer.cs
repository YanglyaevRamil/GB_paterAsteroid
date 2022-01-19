
public class AsteroidTurnByPlayer : ObjectTurnByPlayer
{
    private void OnEnable()
    {
        targetTransform = GetComponentInParent<Asteroid>().TargetTransform;
    }
}
