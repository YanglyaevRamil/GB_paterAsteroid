using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTurnByPlayer : MonoBehaviour
{
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponentInParent<Asteroid>().ship;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ship.transform);
    }
}
