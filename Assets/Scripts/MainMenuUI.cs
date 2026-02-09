using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private Button playBotton;
    [SerializeField] private Button quiteBotton;

    private void Awake()
    {
        playBotton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Kitchen);
        });
        quiteBotton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1.0f;
    }

}
