using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public GameObject BuyButton; //кнопка покупки
    int BuySkin;
    void Start()
    {
        BuySkin = PlayerPrefs.GetInt("BuySkin"); //список купленных скинов
    }

    void Update()
    {
        if (BuySkin==1) //скрыть кнопку загрузки
        {
            BuyButton.SetActive(true);
        }
        else
        {
            BuyButton.SetActive(false);
        }
    }

    public void BuySkins() 
    {
        if(CoinText.coin>=5) //покупка предмета
        {
            CoinText.coin -= 5;
            PlayerPrefs.SetInt("Coins2", CoinText.coin); 
            BuySkin = 2;
            PlayerPrefs.GetInt("BuySkin", BuySkin);
        }
    }
}
