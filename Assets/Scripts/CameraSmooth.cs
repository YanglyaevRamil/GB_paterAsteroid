using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;   //�����/���� ������
    public float speed = 4.0f;   //"�����������" ���������
    public Vector3 offset = new Vector3(0, 2, 0);   //������� ������ ������������ ������/����

    Quaternion quaternion;
    void Update()
    {
        quaternion = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, speed*Time.deltaTime);
    }
}
