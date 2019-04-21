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

    public GameObject BulletToRight, BulletToLeft;     //вводим 2 обьекта - пулю левую и правую
    Vector2 BulletPos;      //задаем переменную, которая будет содержать направление вектора
    public float fireRate = 0f;       //скоростельность
    float NextFire = 0f;      //задержка

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

        if (Input.GetButtonDown("Fire1") && Time.time > NextFire)       //При ЛКМ и должной задержке - стреляем
        {
            NextFire = Time.time + fireRate;
            Fire();
        }
    }

    private void Flip() //Функция разворота 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Fire()     //функция создания пули по направлению facingRight
    {
        BulletPos = transform.position;     //переменная вектор будет изменяться(transform)
        if (facingRight == true)    //стрельба направо
        {
            BulletPos += new Vector2(0.2f, 0f);
            Instantiate(BulletToRight, BulletPos, Quaternion.identity);     //создание копии префаба пули
        }
        else if (facingRight == false)      //стрельба налево
        {
            BulletPos += new Vector2(-0.2f, 0f);
            Instantiate(BulletToLeft, BulletPos, Quaternion.identity);
        }
    }
}
