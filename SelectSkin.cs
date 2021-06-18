using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
    public GameObject Skin1, Skin2; //выбор скинов
    int selectSkin1, selectSkin2;
    void Start()
    {
        selectSkin1 = PlayerPrefs.GetInt("selectSkin1", 1);
        selectSkin2 = PlayerPrefs.GetInt("selectSkin2", 1);
    }

    void Update()
    {
        if(selectSkin1==1)
        {
            Skin1.SetActive(true);
            Skin2.SetActive(false);
        }
        else
        {
            Skin1.SetActive(false);
        }

        if (selectSkin2 == 2) //переключение между скинами
        {
            Skin1.SetActive(false);
            Skin2.SetActive(true);
        }
        else
        {
            Skin2.SetActive(false);
        }
    }
    public void SelectFirstSkin() //выбор первого скина по кнопке
    {
        selectSkin1 = 1; 
        PlayerPrefs.SetInt("selectSkin1", selectSkin1);
        selectSkin2 = 1;
        PlayerPrefs.SetInt("selectSkin2", selectSkin2);
    }
    public void SelectSecondSkin() //выбор второго скина по кнопке
    {
        selectSkin1 = 2;
        PlayerPrefs.SetInt("selectSkin1", selectSkin1);
        selectSkin2 = 2;
        PlayerPrefs.SetInt("selectSkin2", selectSkin2);
    }
}
