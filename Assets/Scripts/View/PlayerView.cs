using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour, IDamageProvider
{
    public event Action<IDamageProvider> OnDamageTaken;
    public event Action OnKeyDownButtonShooting;
    public event Action<Vector3> OnKeyButtonRotation;
    public event Action<Vector3> OnKeyButtonMoving;
    public event Action OnGetDamage;

    private int damage;
    private float horizontalAxis, verticalAxis;
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
        if((horizontalAxis = Input.GetAxis("Horizontal")) != 0)
        {
            OnKeyButtonRotation?.Invoke(new Vector3(0f, horizontalAxis, 0f));
        }
        
        if ((verticalAxis = Input.GetAxis("Vertical")) != 0)
        {
            OnKeyButtonMoving?.Invoke(transform.forward * verticalAxis);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageProvider damage;
        if ((damage = other.gameObject.GetComponent<IDamageProvider>()) != null)
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
