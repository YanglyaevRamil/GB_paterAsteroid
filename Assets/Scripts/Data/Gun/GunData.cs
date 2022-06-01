using UnityEngine;

[CreateAssetMenu(fileName = "New GunData", menuName = "Gun Data", order = 51)]
public class GunData : ScriptableObject
{
    [SerializeField]
    private GunType gunType;

    [SerializeField]
    private string description;

    [SerializeField]
    private int ammunition;

    [SerializeField]
    private float gunRecoilTime;

    [SerializeField]
    private float gunReloadingTime;

    [SerializeField]
    private int bulletNumber;

    [SerializeField]
    private GameObject gunGO;

    [SerializeField]
    private BulletSpawnerModel bulletSpawnerModel;

    public GunType GunType { get { return gunType; } }
    public string Description { get { return description; } }
    public int Ammunition { get { return ammunition; } }
    public float GunRecoilTime { get { return gunRecoilTime; } }
    public float GunReloadingTime { get { return gunReloadingTime; } }
    public int BulletNumber { get { return bulletNumber; } }
    public GameObject GunGO { get { return gunGO; } set { gunGO = value; } }
    public BulletSpawnerModel BulletSpawnerModel { get { return bulletSpawnerModel; } set { bulletSpawnerModel = value; } }
}
