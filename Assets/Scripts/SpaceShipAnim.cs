using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAnim : MonoBehaviour
{
    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;
    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        ShipAnim();
    }

    public void ShipAnim()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
    }
}
