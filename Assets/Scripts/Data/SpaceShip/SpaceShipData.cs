using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceShipData", menuName = "SpaceShip Data", order = 51)]
public class SpaceShipData : ScriptableObject
{
    [SerializeField]
    private SpaceShipType playerType;

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
    private GameObject spaceShipGameObject;

    public SpaceShipType PlayerType { get { return playerType; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public Vector3 RotationSpeed { get { return rotationSpeed; } }
    public int PricePoints { get { return pricePoints; } }
    public GameObject SpaceShipGameObject { get { return spaceShipGameObject; } set { spaceShipGameObject = value; } }
}
