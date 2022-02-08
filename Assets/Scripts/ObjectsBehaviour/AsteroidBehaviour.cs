using System.Collections;
using UnityEngine;
public class AsteroidBehaviour : Enemy
{
    private const float MAX_DELETION = 300.0f;
    private const float DURATION_OF_DEATH = 3.0f;

    [SerializeField] private float radius;

    private MeshRenderer meshRenderer;
    private ParticleSystem partsSystem;
    private SphereCollider sphereCollider;
    private Quaternion rotateAsteroid;

    private Asteroid asteroid;
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>(); 
        partsSystem = GetComponentInChildren<ParticleSystem>();
        partsSystem.Stop();
        transform.localScale = new Vector3(radius, radius, radius);
        rotateAsteroid = Quaternion.AngleAxis(1, new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)));
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        if (targetTransform != null)
        {
            asteroid = new Asteroid(health, transform, GetNormVector(transform.position, targetTransform.position));
        }
    }
    public void AsteroidInitParametr(float speed, int damage, int health, float radius)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.radius = radius;
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.GetComponent<IDamage>()) != null)
        {
            asteroid.DamageTake(damage.Damage);
            if (asteroid.DeathCheck())
            {
                asteroid.Death();
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
        partsSystem.Play();
        SoundManager.Instance.PlaySound("Blow1");
        
    }
    private IEnumerator CountToDeath()
    {
        DestructionAsteroid();
        yield return new WaitForSecondsRealtime(DURATION_OF_DEATH);
        ReturnToPool();
        StopCoroutine(CountToDeath());
    }
}
