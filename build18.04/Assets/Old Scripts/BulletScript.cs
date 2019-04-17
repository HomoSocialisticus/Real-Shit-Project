using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();           //Физические св-ва тела
    }

    void Update()
    {
        rb.velocity = new Vector2(velX, velY);          //Вектор полёта пули
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)       //Ф-ция контакта
    {
        if (collision.gameObject.name == "Enemy")       //Если тег обьекта прикосновения равен Enemy
        {
            Debug.Log("OnCollisionEnter");
        }
        Destroy(gameObject);        //Удаление пули
    }
}
