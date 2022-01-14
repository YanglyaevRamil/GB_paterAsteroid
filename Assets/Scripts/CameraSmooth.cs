using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{

	private float distanceAway = 3f;
	private float distanceUp = 2f;
	private float smooth = 2f;               // how smooth the camera movement is

	private Vector3 m_TargetPosition;       // the position the camera is trying to be in)

	Transform follow;        //the position of Player

	void Start()
	{
		follow = GameObject.FindWithTag("Player").transform;
	}

	void LateUpdate()
	{
		// setting the target position to be the correct offset from the 
		m_TargetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;

		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);

		// make sure the camera is looking the right way!
		transform.LookAt(follow);

		//    public float distance = 8;
		//    // Горизонтальный угол
		//    public float rot = 0; // Выражается в радианах
		//                          // Продольный угол
		//    private float roll = 30f * Mathf.PI * 2 / 360; // радианы
		//                                                   // Целевой объект
		//    public GameObject target;
		//    void LateUpdate()
		//    {
		//        // Некоторые суждения
		//        if (target == null)
		//            return;
		//        if (Camera.main == null)
		//            return;
		//        // Координаты цели
		//        Vector3 targetPos = target.transform.position;
		//        // Используем тригонометрическую функцию для расчета положения камеры
		//        Vector3 cameraPos;
		//        float d = distance * Mathf.Cos(roll);
		//        float height = distance * Mathf.Sin(roll);
		//        cameraPos.x = targetPos.x + d * Mathf.Cos(rot);
		//        cameraPos.z = targetPos.z + d * Mathf.Sin(rot);
		//        cameraPos.y = targetPos.y + height;
		//        Camera.main.transform.position = cameraPos;
		//        // Цельтесь в цель
		//        Camera.main.transform.LookAt(target.transform);
	}
}
