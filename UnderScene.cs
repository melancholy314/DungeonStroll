using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderScene : MonoBehaviour
{
    public string sceneName; //название сцены, которая загрузится 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //если попал герой, то запуск уровня
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
