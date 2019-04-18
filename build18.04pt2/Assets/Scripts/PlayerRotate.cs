using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour {

    public float speed = 5f;

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;   //Определяем направление с помощью камеры и положения курсора
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    //ВЫсчитываем угол поворота
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);    //Собственно начало вращения 
    }
}
