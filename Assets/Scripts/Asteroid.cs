using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamage
{
    private const int MIN_DAMAGE = 5;
    private const int MAX_DAMAGE = 15;
    private const int MIN_HP = 1;
    private const int MAX_HP = 3;
    private const float MAX_DELETION = 300.0f;
    private const float MIN_SPEED = 0.1f;
    private const float MAX_SPEED = 0.3f;
    private const float DURATION_OF_DEATH = 3.0f;

    public GameObject ship;

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int health;

    private MeshRenderer meshRenderer;
    private SpriteRenderer spriteRenderer;
    private ParticleSystem partsSystem;
    private SphereCollider sphereCollider;
    private Transform transformShip;
    private Transform transformAsteroid;

    private SpaceStone spaceStone;
    private SpaceStoneDead spaceStoneDead;
    private SpaceStoneMoving spaceStoneMoving;
    public int Damage { get => damage; }

    private void OnEnable()
    {
        if (GetComponentInChildren<SpriteRenderer>() != null) { spriteRenderer = GetComponentInChildren<SpriteRenderer>(); }
        if (GetComponentInChildren<MeshRenderer>() != null) { meshRenderer = GetComponentInChildren<MeshRenderer>(); }
        partsSystem = GetComponentInChildren<ParticleSystem>();
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;
        sphereCollider = gameObject.GetComponent<SphereCollider>();

        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE);
        health = Random.Range(MIN_HP, MAX_HP);

        partsSystem.Stop();

        spaceStoneMoving = new SpaceStoneMoving(transformAsteroid, transformShip, speed);
        spaceStoneDead = new SpaceStoneDead(health);
        spaceStone = new SpaceStone(spaceStoneMoving, spaceStoneDead);
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
    }
    private void Update()
    {
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;

        var vec = transformShip.position - transformAsteroid.position;

        if (vec.magnitude > MAX_DELETION)
        {
            Destroy(gameObject);
        }
    }

    private void DestructionAsteroid()
    {
        if (spriteRenderer != null) { spriteRenderer.enabled = false; }
        if (meshRenderer != null) { meshRenderer.enabled = false; }
        sphereCollider.enabled = false;
        partsSystem.Play();
    }
    private IEnumerator CountToDeath()
    {
        DestructionAsteroid();
        yield return new WaitForSecondsRealtime(DURATION_OF_DEATH);
        Destroy(gameObject);
        StopCoroutine(CountToDeath());
    }
}
