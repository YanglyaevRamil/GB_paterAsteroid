
using UnityEngine;

public class Bullet : SpaceObject
{
    private const float TIME_DEATH = 10f;
    private const float SPEED_BULLET = 1.5f;

    private void Start()
    {
        Destroy(gameObject, TIME_DEATH);
    }

    private void FixedUpdate()
    {
        Motion();
    }

    private void OnEnable()
    {
        speed = SPEED_BULLET;
    }

    public override bool Death()
    {
        Destroy(gameObject);
        return true;
    }

    public override void Motion()
    {
        transform.Translate(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }
}
