using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopMenu; //выбор, где находится магазин на сцене
    void Start()
    {
        ShopMenu.SetActive(false);
    }
    public void OpenShopMenu() //открытие магазина
    {
        ShopMenu.SetActive(true);
    }
    public void CloseShopMenu() //закрытие магазина
    {
        ShopMenu.SetActive(false);
    }
}
