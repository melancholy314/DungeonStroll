using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private float speed = 5.0f; //скорость
    [SerializeField] private int lives = 3; //количество жизней

    public int Lives //изменение и получение жизней
    {
        get
        {
            return lives;
        }

        set
        {
            if (value < 3) lives = value;
            liveBar.Refresh();
        }
    }
    private LiveBar liveBar; 

    [SerializeField] private float jumpForce = 10.0f; //высота прыжка

    private bool isGrounded = false; //наличие земли под ногами

    private Ball ball;

    private CharState State //анимация
    {
        get
        {
            return (CharState)animator.GetInteger("State");
        }
        set
        {
            animator.SetInteger("State", (int) value);
        }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        liveBar = FindObjectOfType<LiveBar>(); //поиск сердец на сцене
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        ball = Resources.Load<Ball>("Ball");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle; //анимация покоя
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run() //движение персонажа
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x > 0; //отзеркаливание

        if (isGrounded) State = CharState.Run; //переключение анимации на бег
    }

    private void Jump() //прыжок
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot() //стрельба
    {
        Vector3 position = transform.position; //позиция начала движения мяча 
        position.y += 0.6f; 
        position.x -= 2.0f;

        Ball newBall = Instantiate(ball, position, ball.transform.rotation) as Ball;
        newBall.Parent = gameObject;
        newBall.Direction = newBall.transform.right * (sprite.flipX ? 1.0f : -1.0f);
    }

    private void CheckGround() //проверка наличия земли под ногами
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump; //переключение анимации на прыжок
    }

    public override void RecieveDamage() //изменение количества жизней
    {
        Lives--;
        if (lives==0) //если жизней нет, то герой умирает
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();

        if (unit) //получение урона от других существ
        {
            RecieveDamage();  
        }
    }
}

public enum CharState //массив анимаций
{
    Idle,
    Run,
    Jump
}