using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceShipData", menuName = "SpaceShip Data", order = 51)]
public class SpaceShipData : ScriptableObject
{
    [SerializeField]
    private SpaceShipType shipType;

    [SerializeField]
    private string description;

    [SerializeField, Range(0, 100)]
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
    private GameObject spaceShipGO;

    [SerializeField]
    private GunModel gunModel;

    [SerializeField]
    private UserInputModel userInputModel;

    public SpaceShipType PlayerType { get { return shipType; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public Vector3 RotationSpeed { get { return rotationSpeed; } }
    public int PricePoints { get { return pricePoints; } }

    public GameObject SpaceShipGO { get { return spaceShipGO; } set { spaceShipGO = value; } }
    public UserInputModel UserInputModel { get { return userInputModel; } set { userInputModel = value; } }
    public GunModel GunModel { get { return gunModel; } set { gunModel = value; } }
}
