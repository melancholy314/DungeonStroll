using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    public Button button; //выбор кнопки вручную

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit(); //закрытие приложения
    }
}
