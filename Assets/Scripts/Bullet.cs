using UnityEngine;

public class Bullet : MonoBehaviour, IDamage
{
    private const float TIME_DEATH = 10f;
    private const float SPEED_BULLET = 1.5f;

    [SerializeField] private int damage = 1;
    public int Damage { get => damage; }

    private void Start()
    {
        Destroy(gameObject, TIME_DEATH);
    }
    private void FixedUpdate()
    {
        Motion();
    }
    public bool Death()
    {
        Destroy(gameObject);
        return true;
    }
    public void Motion()
    {
        transform.Translate(Vector3.forward * SPEED_BULLET);
    }
    private void OnTriggerEnter(Collider other)
    {
        Death();
    }
}
