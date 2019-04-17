using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float speed;
    private float waitTime;
    public float startWaitTime;

    private Rigidbody2D rBody;
    private bool facingLeft = true;

    public Transform[] moveSpots; //Массив позиций, куда враг может двигаться 
    private int randomSpot;

    private void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        if(transform.position.x > moveSpots[randomSpot].position.x && !facingLeft)  //Проверка направления движения и в какую сторону смотрит враг
        {
            Flip();
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);   //Движение из текущего места в рандомную заданную заранее точку
        }
        else if(transform.position.x < moveSpots[randomSpot].position.x && facingLeft)
        {
            Flip();
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) //Проверяем насколько близко враг находится к конечной точке
        {
            if(waitTime <= 0)   //Проверяем время ожидания
            {
                randomSpot = Random.Range(0, moveSpots.Length); //<= 0 - задаем следующую случайную точку для передвидения
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime; //Нет - отнимаем время ожидания
            }
        }
    }

    protected void Flip() //Функция разворота (Абсолютно не повторяющаяся)
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
