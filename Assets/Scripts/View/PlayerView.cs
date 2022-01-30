using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    public event Action<IDamage> OnDamageTaken;
    public event Action OnKeyDownButtonShooting;
    private InputSystem inputSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnKeyDownButtonShooting?.Invoke();
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
}
