using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDelete : MonoBehaviour
{
    public Button button; //указание кнопки вручную

    void Start()
    {
        button.onClick.AddListener(DeleteSave); //удаление сохранений по нажатию кнопки
    }

    void DeleteSave()
    {
        PlayerPrefs.DeleteKey("levels1");
    }
}
