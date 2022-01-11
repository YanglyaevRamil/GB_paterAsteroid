using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAnim : MonoBehaviour
{
    private Animator animator;
    private SpaceShip spaceShip;
    private void Start()
    {
        animator = GetComponent<Animator>();
        spaceShip = GetComponent<SpaceShip>();
    }
    private void FixedUpdate()
    {
        ShipAnim();
    }
    public void ShipAnim()
    {
        if (spaceShip.shipSpin == 1)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        if (spaceShip.shipSpin == -1)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
    }
}
