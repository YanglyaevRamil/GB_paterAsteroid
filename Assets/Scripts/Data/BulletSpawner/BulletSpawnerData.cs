using UnityEngine;

[CreateAssetMenu(fileName = "New AsteroidSpawnerData", menuName = "Bullet SpawnerData Data", order = 51)]
public class BulletSpawnerData : ScriptableObject
{
    [SerializeField]
    private float timerTick;

    [SerializeField]
    private int numBulletInGrup;

    [SerializeField]
    private BulletType bulletType;

    public float TimerTick { get { return timerTick; } }
    public int NumBulletInGrup { get { return numBulletInGrup; } }
    public BulletType BulletType { get { return bulletType; } set { bulletType = value; } }
}