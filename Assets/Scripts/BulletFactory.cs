using UnityEngine;

public class BulletFactory
{
    public Bullet Create(float speed, int damage)
    {
        Bullet bullet = Object.Instantiate(Resources.Load<Bullet>("Bullet_0"));
        bullet.BulletInitParametr(speed, damage);
        return bullet;
    }
}
