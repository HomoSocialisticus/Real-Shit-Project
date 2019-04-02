using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rBody;

    private float moveInput;
    public float runSpeed = 10f;

    public float jumpForce;
    private int extraJumps;
    public int extraJumpValue = 2;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;  //Проверка типа слоя

    private void Start()
    {
        extraJumps = extraJumpValue;
        rBody = GetComponent<Rigidbody2D>();    //Привязываем к скрипту rigidbody
    }

    void FixedUpdate ()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal") * runSpeed; //Задаем 1/-1 и ускоряем по оси х
        rBody.velocity = new Vector2(moveInput * runSpeed, rBody.velocity.y);   //Воздействуем на RigidBody

        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight) //Проверяем в какую сторону смотрит персонаж и в какую сторону он должен двигаться
            Flip();
    }

    private void Update()
    {
        if (isGrounded == true) //Проверка на то, стоит ли персонаж на земле
            extraJumps = extraJumpValue;    //Если да - возвращается количоство доступных прыжков

        if (Input.GetButtonDown("Jump") && extraJumps > 0)  //Если нажата кнопка прыжка и количоство прыжков больше 0
        {
            rBody.velocity = Vector2.up * jumpForce;    //Персонаж прыгнет (Неожиданно)
            --extraJumps;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)  //если он только приземлился
        {                                                       //То он может снова начать прыгать без какой либо задержки
            rBody.velocity = Vector2.up * jumpForce;
        }
    }

    private void Flip() //Функция разворота 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
