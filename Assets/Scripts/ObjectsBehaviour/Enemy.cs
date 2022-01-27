using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    public int Damage { get => damage; }
    public Transform TargetTransform
    {
        set { targetTransform = value; }
    }
    [SerializeField] protected Transform targetTransform;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected int health;
    protected void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
    protected Vector3 GetNormVector(Vector3 a, Vector3 b)
    {
        return (b - a) / (b - a).magnitude;
    }
}
