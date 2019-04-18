using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour {

    public float speed = 5f;
    public GameObject player;

    private void Update()
    {
        Vector2 direction = player.transform.position;   //Определяем положение игрока
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    //ВЫсчитываем угол поворота
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);    //Собственно начало вращения 
    }
}
