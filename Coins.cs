using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) //прибавление монет, если к ним прикасается игрок
        {
            CoinText.coin += 1;
            PlayerPrefs.SetInt("Coins2", CoinText.coin);
            Destroy(gameObject);
        }
    }
}
