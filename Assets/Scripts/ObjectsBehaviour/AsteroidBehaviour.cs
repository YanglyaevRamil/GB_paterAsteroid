using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidBehaviour : MonoBehaviour, IDamage, IPricePoints
{
    private const float MAX_DELETION = 300.0f;
    private const float DURATION_OF_DEATH = 3.0f;

    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private float radius;
    [SerializeField] private int pricePoints;

    public int Damage { get => damage; }
    public Transform TargetTransform
    {
        set { targetTransform = value; }
    }
    public int PricePoints { get => pricePoints; }

    private MeshRenderer meshRenderer;
    private SphereCollider sphereCollider;
    private Quaternion rotateAsteroid;
    private Asteroid asteroid;
    public UnityEvent unityEventHit;
    public UnityEvent unityEventDeath;
    public delegate void OnAsteroidDead(IPricePoints asteroidPricePoints);
    public static event OnAsteroidDead onAsteroidDead;

    private void OnEnable()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        transform.localScale = new Vector3(radius, radius, radius);
        rotateAsteroid = Quaternion.AngleAxis(1, new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)));
        if (targetTransform != null)
        {
            asteroid = new Asteroid(health, transform, GetNormVector(transform.position, targetTransform.position));
        }
    }

    public void AsteroidInitParametr(float speed, int damage, int health, float radius, int pricePoints)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.radius = radius;
        this.pricePoints = pricePoints;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.GetComponent<IDamage>()) != null)
        {
            asteroid.DamageTake(damage.Damage);
            if (asteroid.DeathCheck())
            {
                unityEventDeath?.Invoke();
                onAsteroidDead?.Invoke(this);
                StartCoroutine(CountToDeath());
            }
        }
    }

    private void FixedUpdate()
    {
        asteroid.Moving(speed);
        asteroid.Rotation(rotateAsteroid);
    }

    private void Update()
    {
        if (targetTransform != null)
        {
            var vec = targetTransform.position - transform.position;

            if (vec.magnitude > MAX_DELETION)
            {
                ReturnToPool();
            }
        }
    }

    private void DestructionAsteroid()
    {
        if (meshRenderer != null) { meshRenderer.enabled = false; }
        sphereCollider.enabled = false;
        SoundManager.Instance.PlaySound("Blow1");
    }
    private IEnumerator CountToDeath()
    {
        DestructionAsteroid();
        yield return new WaitForSecondsRealtime(DURATION_OF_DEATH);
        ReturnToPool();
        StopCoroutine(CountToDeath());
    }
    protected Vector3 GetNormVector(Vector3 a, Vector3 b)
    {
        return (b - a) / (b - a).magnitude;
    }
    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}