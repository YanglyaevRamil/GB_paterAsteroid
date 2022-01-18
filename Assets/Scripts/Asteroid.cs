using System.Collections;
using UnityEngine;
public class Asteroid : MonoBehaviour, IDamage
{
    private const float MAX_DELETION = 300.0f;
    private const float DURATION_OF_DEATH = 3.0f;

    public GameObject ship;

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private float radius;
    [SerializeField] private int coefficientSize;

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
        partsSystem.Stop();
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;
        coefficientSize = Random.Range(1, 3);
        transformAsteroid.localScale = new Vector3(radius, radius, radius);
        rotateAsteroid = Quaternion.AngleAxis(1, new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)));
        sphereCollider = gameObject.GetComponent<SphereCollider>();

        spaceStoneMoving = new SpaceStoneMoving(transformAsteroid, transformShip, speed);
        spaceStoneDead = new SpaceStoneDead(health);
        spaceObjectRotation = new SpaceObjectRotation(transformAsteroid);
        spaceStone = new SpaceStone(spaceStoneMoving, spaceStoneDead, spaceObjectRotation);
        
    }
    public void AsteroidInitParametr(float speed, int damage, int health, float radius)
    {
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.radius = radius;
    }
    public void AsteroidBuilder(SpaceStoneMoving spaceStoneMoving, SpaceStoneDead spaceStoneDead, SpaceObjectRotation spaceObjectRotation)
    {
        this.spaceStoneMoving = spaceStoneMoving;
        this.spaceStoneDead = spaceStoneDead;
        this.spaceObjectRotation = spaceObjectRotation;
        spaceStone = new SpaceStone(this.spaceStoneMoving, this.spaceStoneDead, this.spaceObjectRotation);
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
            ReturnToPool();
            //Destroy(gameObject);
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
        //Destroy(gameObject);
        ReturnToPool();
        StopCoroutine(CountToDeath());
    }
    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
