using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GoToNextLvl : MonoBehaviour
{
    public int auth;
    public void Start()
    {
       string login = System.IO.File.ReadAllText(@"C:\DS\Login.txt");
        print(login);
        auth = Convert.ToInt32(login);
        print(auth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) //если тег объекта "игрок", то перейти в меню уровней
        {
            UnlockLevel();
            SceneManager.LoadScene(1);
        }
    }

    public void UnlockLevel() //открыть остальные уровни
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (auth == 1)
        {
            print(auth);
            if (currentLevel >= PlayerPrefs.GetInt("levels1"))
            {
                PlayerPrefs.SetInt("levels1", currentLevel + 1); //открыть следующий уровень
            }
        }
    }
}
