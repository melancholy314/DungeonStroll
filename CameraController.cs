using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f; //скорость движения камеры
    private Transform target;

    public void Awake()
    {
        target = FindObjectOfType<Player>().transform; //автопоиск цели
    }
    private void Update()
    {
        Awake();
        Vector3 position = target.position;
        position.z = -10.0f; //отдаление камеры
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime); //передвижение за целью
    }
}