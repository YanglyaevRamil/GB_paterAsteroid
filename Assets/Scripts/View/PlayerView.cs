using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour, IDamage
{
    public event Action<IDamage> OnDamageTaken;
    public event Action OnKeyDownButtonShooting;
    public event Action OnKeyButtonRotationLeft;
    public event Action OnKeyButtonRotationRight;
    public event Action OnKeyButtonMoving;
    public event Action OnGetDamage;

    private int damage;
    public int Damage 
    { 
        get 
        {
            OnGetDamage?.Invoke();
            return damage;
        } 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnKeyDownButtonShooting?.Invoke();
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            OnKeyButtonRotationLeft?.Invoke();
        }
        if (Input.GetKey(KeyCode.D))
        {
            OnKeyButtonRotationRight?.Invoke();
        }
        if (Input.GetKey(KeyCode.W))
        {
            OnKeyButtonMoving?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamage damage;
        if ((damage = other.gameObject.GetComponent<IDamage>()) != null)
        {
            OnDamageTaken?.Invoke(damage);
        }
    }
    public void Dead()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    public void GetDamage(int damage)
    {
        this.damage = damage;
    }
}
