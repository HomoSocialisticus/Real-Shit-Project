using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float velX = 0.5f;
    float velY = 0f;
    Rigidbody2D rb;
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
	
    void OnBecameInvisible()
    {
        enabled = true;
        //Destroy(gameObject);    //если пульку не видно - ломаем
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);        //уничтожение пули
        Destroy(collision.gameObject);      //уничтожение обьекта, с которым контактирует пуля
    }
    
    void Update () {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 5f);      //ломаем пульку через 5 секунд после выстрела
        
        //пока что не решил, как лучше избавляться от пули, которая ултает в небытие

    }
}
