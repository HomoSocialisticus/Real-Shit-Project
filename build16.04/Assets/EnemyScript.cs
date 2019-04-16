using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    Rigidbody2D rb;
    private float HealthPoints = 100f;

    void Start () {
        rb = GetComponent<Rigidbody2D>();       //Физические св-ва тела
    }

	void Update () {
        if (HealthPoints <= 0)
        {
            Destroy(gameObject);       //смэрт при отсутствии HP
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)       //Ф-ция контакта
    {
        if(collision.gameObject.tag  == "Bullet")       //Если тег обьекта прикосновения равен bullet
        {
            Destroy(collision.gameObject);       //уничтожение обьекта прикосновения
            Debug.Log("Bullet destroyed");
            
            HealthPoints -= 12.5f;      //Не забыть: пуля снимает х2 здоровья
        }
        Debug.Log(HealthPoints);
    }
}
