using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColision : MonoBehaviour {

    private PlatformEffector2D effector;
    public float waitTime;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(Input.GetButtonUp("Jump off"))   //Проверяем нажата ли кнопка "Вниз"
        {
            waitTime = 0.1f;    //Веремя перед тем, как спрыгнуть вниз добавляется если кнопка не нажата
        }

        if(Input.GetButton("Jump off")) //Если кнопка нажата
        {
            if(waitTime <= 0)   //И время <=0
            {
                effector.rotationalOffset = 180f;   //Разварачиваем эффектор на 180
                waitTime = 0.1f;    //И добавляем время ожидания
            }
            else
            {
                waitTime -= Time.deltaTime; //В противном случае отнимае от времени ождиания общее время
            }
        }

        if(Input.GetButton("Jump")) //Елси нажата кнопка прыжка
        {
            effector.rotationalOffset = 0;  //То эффектор не разварачивается 
        }
    }
}
