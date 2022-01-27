using UnityEngine;

public class BulletFactory
{
    public BulletBehaviour Create(float speed, int damage)
    {
        BulletBehaviour bullet = Object.Instantiate(Resources.Load<BulletBehaviour>("Bullet_0"));
        bullet.BulletInitParametr(speed, damage);
        bullet.name = "Bullet";
        return bullet;
    }
}
