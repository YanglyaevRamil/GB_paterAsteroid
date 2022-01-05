using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SpaceObject
{
    private void Start()
    {
        Destroy(gameObject, 50f);
    }

    private void FixedUpdate()
    {
        Motion();
    }

    public override bool Death()
    {
        Destroy(gameObject);
        return true;
    }

    public override void Motion()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }
}
