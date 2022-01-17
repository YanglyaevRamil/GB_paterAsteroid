using System.Collections;
using UnityEngine;
public class Asteroid : MonoBehaviour, IDamage
{
    private const float MIN_SIZE = 0.5f;
    private const int MIN_DAMAGE = 5;
    private const int MAX_DAMAGE = 15;
    private const int MIN_HP = 1;
    private const int MAX_HP = 3;
    private const float MAX_DELETION = 300.0f;
    private const float MIN_SPEED = 0.1f;
    private const float MAX_SPEED = 0.3f;
    private const float DURATION_OF_DEATH = 3.0f;
    private const float ROTATESPEEDASTEROID = 1.0f;

    public GameObject ship;

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private int coefficientSize;

    private GameObject asteroidPrefab;
    private MeshRenderer meshRenderer;
    private SpriteRenderer spriteRenderer;
    private ParticleSystem partsSystem;
    private SphereCollider sphereCollider;
    private Transform transformShip;
    private Transform transformAsteroid;
    private Quaternion rotateAsteroid;

    private SpaceStone spaceStone;
    private SpaceStoneDead spaceStoneDead;
    private SpaceStoneMoving spaceStoneMoving;
    private SpaceObjectRotation spaceObjectRotation;
    
    public int Damage { get => damage; }

    private void OnEnable()
    {
       
        if (GetComponentInChildren<SpriteRenderer>() != null) { spriteRenderer = GetComponentInChildren<SpriteRenderer>(); }
        if (GetComponentInChildren<MeshRenderer>() != null) { meshRenderer = GetComponentInChildren<MeshRenderer>(); }
        partsSystem = GetComponentInChildren<ParticleSystem>();

        transformShip = ship.GetComponent<Transform>();

        transformAsteroid = gameObject.transform;
        coefficientSize = Random.Range(1, 3);
        transformAsteroid.localScale = new Vector3(MIN_SIZE*coefficientSize, MIN_SIZE*coefficientSize, MIN_SIZE*coefficientSize);

        sphereCollider = gameObject.GetComponent<SphereCollider>();

        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        damage = MIN_DAMAGE * coefficientSize; //Random.Range(MIN_DAMAGE, MAX_DAMAGE)
        health = MIN_HP * coefficientSize; //Random.Range(MIN_HP, MAX_HP);
        rotateAsteroid = Quaternion.AngleAxis(ROTATESPEEDASTEROID, new Vector3(Random.Range(-1,2), Random.Range(-1, 2), Random.Range(-1, 2)));

        spaceStoneMoving = new SpaceStoneMoving(transformAsteroid, transformShip, speed);
        spaceStoneDead = new SpaceStoneDead(health);
        spaceObjectRotation = new SpaceObjectRotation(transformAsteroid);
        spaceStone = new SpaceStone(spaceStoneMoving, spaceStoneDead, spaceObjectRotation);

        partsSystem.Stop();
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

    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);

    }
}
