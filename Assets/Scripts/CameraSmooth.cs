using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
	public Transform target;
	private float smoothSpeed = 3f;               // how smooth the camera movement is
    private Vector3 offset = new Vector3(0,2,-6);
    private Vector3 smoothPosition;
    private void LateUpdate()
    {
        Debug.Log(transform.position);
        smoothPosition = Vector3.Lerp(transform.position, target.position+ offset, smoothSpeed);
        
        transform.position = smoothPosition;

        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref offset, smoothSpeed) + offset; //плавно перемещает камеру в точку координату персонажа
        //transform.forward = Vector3.SmoothDamp(transform.forward, target.forward, ref offset, smoothSpeed); //плавно перемещает forward (поворачивает) cameraRig чтобы смотреть в то же место, куда и персонаж.

        //можно еще иметь ссылку на саму камеру и сделать что-то типа
        //cam.transform.LookAt(character.position); // смотрит на персонажа

    }
}
