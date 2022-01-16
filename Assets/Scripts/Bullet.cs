using UnityEngine;

public class Bullet : MonoBehaviour, IDamage
{
    private const float TIME_DEATH = 10f;
    private const float SPEED_BULLET = 1.5f;

    public int Damage { get => usualBullet.Damage; }

    private UsualBullet usualBullet;
    private void Start()
    {
        usualBullet = new UsualBullet(transform, SPEED_BULLET);
        Destroy(gameObject, TIME_DEATH);
    }
    private void FixedUpdate()
    {
        usualBullet.Motion();
    }
    public bool Death()
    {
        Destroy(gameObject);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }
}