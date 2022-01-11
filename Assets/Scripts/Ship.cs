

public abstract class Ship : SpaceObject
{
    public int health;
    public int ammunition;
    public float rotateSpeed;

    public abstract bool Shooting();
}