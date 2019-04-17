using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStealth : MonoBehaviour {

    public float distance;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Update ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);    //Создаем луч видимости врагу (откуда начинается, куда направить, расстояние)
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);   //Елси в луч попадает объект - тревога
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);   //Иначе ничего
        }
    }
}
