using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager: MonoBehaviour 
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletContainer;
    [SerializeField] private List<GameObject> _bulletPool;
    [SerializeField] private int _bullets;
    
    private static BulletPoolManager _instance;
    public GameObject playerGameObject;
    private Player player;

    public static BulletPoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Pool is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _bulletPool = GenerateBullets(_bullets);
        player = playerGameObject.GetComponent<Player>();
    }

    private void Update()
    {
        Shoot();
    }
    private List<GameObject> GenerateBullets(int numberOfBullets)
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _bulletContainer.transform.position;
            bullet.transform.rotation = _bulletContainer.transform.rotation;
            bullet.SetActive(false);
            _bulletPool.Add(bullet);

        }
        return _bulletPool;
    }

    public GameObject FindBullet()
    {
        foreach (var bullet in _bulletPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                bullet.transform.position = _bulletContainer.transform.position;
                bullet.transform.rotation = _bulletContainer.transform.rotation;
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(_bulletPrefab);
        newBullet.transform.position = _bulletContainer.transform.position;
        newBullet.transform.rotation = _bulletContainer.transform.rotation;
        _bulletPool.Add(newBullet);
        return newBullet;
    }

    private void Shoot()
    {
        if (player.Shooting)
        {
            GameObject bullet = BulletPoolManager.Instance.FindBullet();
        }
    }
}
