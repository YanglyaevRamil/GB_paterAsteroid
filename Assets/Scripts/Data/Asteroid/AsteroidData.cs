using UnityEngine;

[CreateAssetMenu(fileName = "New AsteroidData", menuName = "Asteroid Data", order = 51)]
public class AsteroidData : ScriptableObject
{
    [SerializeField]
    private AsteroidType asteroidType;

    [SerializeField]
    private string description;

    [SerializeField]
    private int health;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 rotationSpeed;

    [SerializeField]
    private int pricePoints;

    [SerializeField]
    private GameObject asteroidGameObject;

    [SerializeField]
    private Transform asteroidTarget;

    public AsteroidType AsteroidType { get { return asteroidType; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public Vector3 RotationSpeed { get { return rotationSpeed; } }
    public int PricePoints { get { return pricePoints; } }
    public GameObject AsteroidGameObject { get { return asteroidGameObject; } set { asteroidGameObject = value; } }
    public Transform AsteroidTarget { get { return asteroidTarget; } set { asteroidTarget = value; } }
}
