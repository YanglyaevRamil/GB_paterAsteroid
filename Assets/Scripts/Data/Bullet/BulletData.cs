using UnityEngine;

[CreateAssetMenu(fileName = "New BulletDataData", menuName = "Bullet Data", order = 51)]
public class BulletData : ScriptableObject
{
    [SerializeField]
    private BulletType bulletType;

    [SerializeField]
    private string description;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private int bulletDamage;

    [SerializeField]
    private GameObject bulletGO;

    public BulletType BulletType { get { return bulletType; } }
    public string Description { get { return description; } }
    public float BulletSpeed { get { return bulletSpeed; } }
    public int BulletDamage { get { return bulletDamage; } }
    public GameObject BulletGO { get { return bulletGO; } set { bulletGO = value; } }
}
