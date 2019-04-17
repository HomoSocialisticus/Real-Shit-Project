using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed = 5f;
    public float stoppingDistance = 20f;
    public float retreatDistance = 10f;

    public Transform player;
 

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  //Указываем за кем будет "охоиться" противник
	}
	
	void Update ()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)    //Если противник далеко от игрока, то он начнет к нему приближаться до определенной дистанции
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;   //Останавливаем врага
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); //Заставляем его бежать как сучку
        }


    }
}
