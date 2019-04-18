using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	void Start ()
    {
        offset = transform.position - player.transform.position;    //Вычисляем смещение
	}
	
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;    //Передвигаем камеру
	}
}
