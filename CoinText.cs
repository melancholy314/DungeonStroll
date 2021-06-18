using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    public static int coin;
    void Start()
    {
        CoinTexts = GetComponent<Text>(); //взаимодействие с компонентом объекта
        coin = PlayerPrefs.GetInt("Coins2", coin);
    }

    void Update()
    {
        CoinTexts.text = coin.ToString(); //обновление текста
    }
}
