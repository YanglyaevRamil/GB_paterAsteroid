using UnityEngine;

public class ObjectTurnByPlayer : MonoBehaviour
{
    public Transform targetTransform;
    void Update()
    {
        transform.LookAt(targetTransform);
    }
}
