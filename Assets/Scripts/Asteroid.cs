using System.Collections;
using UnityEngine;
public class Asteroid : Enemy
{
    private const float MAX_DELETION = 300.0f;
    private const float DURATION_OF_DEATH = 3.0f;

    [SerializeField] private float radius;

    private MeshRenderer meshRenderer;
    private SpriteRenderer spriteRenderer;
    private ParticleSystem partsSystem;
    private SphereCollider sphereCollider;
    private Transform transformAsteroid;
    private Quaternion rotateAsteroid;

    private SpaceStone spaceStone;
    private SpaceStoneDead spaceStoneDead;
    private SpaceStoneMoving spaceStoneMoving;
    private SpaceObjectRotation spaceObjectRotation;
    private void OnEnable()
    {
        if (GetComponentInChildren<SpriteRenderer>() != null) { spriteRenderer = GetComponentInChildren<SpriteRenderer>(); }
        if (GetComponentInChildren<MeshRenderer>() != null) { meshRenderer = GetComponentInChildren<MeshRenderer>(); }
        partsSystem = GetComponentInChildren<ParticleSystem>();
        partsSystem.Stop();
        transformAsteroid = gameObject.transform;
        transformAsteroid.localScale = new Vector3(radius, radius, radius);
        rotateAsteroid = Quaternion.AngleAxis(1, new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)));
        sphereCollider = gameObject.GetComponent<SphereCollider>();

        if (targetTransform != null)
        {
            spaceStoneMoving = new SpaceStoneMoving(transformAsteroid, targetTransform, speed);
            spaceStoneDead = new SpaceStoneDead(health);
            spaceObjectRotation = new SpaceObjectRotation(transformAsteroid);
            spaceStone = new SpaceStone(spaceStoneMoving, spaceStoneDead, spaceObjectRotation);
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
            spaceStone.DamageTake(damage.Damage);
            if (spaceStone.DeathCheck())
            {
                spaceStone.Death();
                StartCoroutine(CountToDeath());
            }
        }
    }
    private void FixedUpdate()
    {
        spaceStone.Moving();
        spaceStone.Rotation(rotateAsteroid);
    }
    private void Update()
    {
        var vec = targetTransform.position - transformAsteroid.position;

        if (vec.magnitude > MAX_DELETION)
        {
            ReturnToPool();
        }
    }

    private void DestructionAsteroid()
    {
        if (spriteRenderer != null) { spriteRenderer.enabled = false; }
        if (meshRenderer != null) { meshRenderer.enabled = false; }
        sphereCollider.enabled = false;
        partsSystem.Play();
        SoundManager.Instance.PlaySound("Blow1");
    }
    private IEnumerator CountToDeath()
    {
        DestructionAsteroid();
        yield return new WaitForSecondsRealtime(DURATION_OF_DEATH);
        //Destroy(gameObject);
        ReturnToPool();
        StopCoroutine(CountToDeath());
    }
}
