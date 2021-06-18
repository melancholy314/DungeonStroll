using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDelete : MonoBehaviour
{
    public Button button; //указание кнопки вручную

    void Start()
    {
        button.onClick.AddListener(DeleteSave); //удаление монет по нажатию кнопки
    }

    void DeleteSave()
    {
        PlayerPrefs.DeleteKey("Coins2");
    }
}
