using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[3]; //массив сердец на экране
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>(); //поиск игрока на сцене
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh() //изменение количества сердец
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
