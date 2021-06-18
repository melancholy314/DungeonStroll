using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; //скорость полёта шара
    private Vector3 direction; //направление полёта шара

    private GameObject parent; //тот, кто выпустил шар
    public GameObject Parent //определение того, кто выпустил шар
    {
        set
        {
            parent = value;
        }
    }

    public Vector3 Direction //направление полёта шара
    {
        set
        {
            direction = value;
        }
    }

    private SpriteRenderer sprite; //текущий спрайт

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>(); //получение текущего спрайта
    }

    private void Start()
    {
        Destroy(gameObject, 2.0f); //уничтожение шара после определённог времени
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); //движение шара
        sprite.flipX = direction.x > 0; //отзеркаливание спрайта
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();

        if (unit && unit.gameObject != parent) //уничтожение существа при столкновении, если оно не является тем, кто выпустил шар
        {
            Destroy(gameObject);
        }
    }
}
