using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;   //игрок/цель камеры
    public float speed = 4.0f;   //"коэффициент" плавности
    public Vector3 offset = new Vector3(0, 2, 0);   //позиция камеры относительно игрока/цели

    Quaternion quaternion;
    void Update()
    {
        quaternion = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, speed*Time.deltaTime);
    }
}
