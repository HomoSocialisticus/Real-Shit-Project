using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;

    private Transform target; 

    void Start () {

        target = GameObject.Find("Player").transform;
	}
	
	void LateUpdate () {

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z); //Привязали позицию камеры к позиции игрока
	}
}
