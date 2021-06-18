using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ghost : Enemy
{
    [SerializeField] private float speed = 4.0f; //скорость существа
    [SerializeField] public int lives = 1;

    private Vector3 direction;
    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>(); //берём текущий спрайт объекта
    }

    protected override void Update() 
    {
        Move();  //постоянное движение существа
    }

    protected override void Start()
    {
        direction = -transform.right; //задаём направление
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Unit unit = collision.gameObject.GetComponent<Unit>();

        if (unit && unit is Player) //нанесение урона игроку
        {
                unit.RecieveDamage();
        }

        Ball ball = collision.gameObject.GetComponent<Ball>();
        {
            if (ball)  //получение урона от шара
            {
                lives = lives - 1;
                if (lives == 0)
                {
                    RecieveDamage();
                }
            }
        }
    }

    private void Move()  //движение
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.001f + transform.right * direction.x, 0.1f); //поиск препятствий

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Player>()))
        {
            direction *= -1; //изменение направления 
            sprite.flipX = direction.x > 0;  //отзеркаливание текущего спрайта
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); //принцип движения
    }
}
