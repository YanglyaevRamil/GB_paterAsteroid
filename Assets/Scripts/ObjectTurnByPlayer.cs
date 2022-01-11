using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTurnByPlayer : MonoBehaviour
{
    public GameObject ship;
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ship.transform);
    }
}
