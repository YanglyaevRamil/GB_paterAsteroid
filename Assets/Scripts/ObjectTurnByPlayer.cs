using UnityEngine;

public class ObjectTurnByPlayer : MonoBehaviour
{
    public GameObject ship;
    void Update()
    {
        transform.LookAt(ship.transform);
    }
}
