using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUImanager : MonoBehaviour
{
    private MainMenuLight _light;
    private void Start()
    {
        Time.timeScale = 1f;
        _light = GameObject.Find("Light_Controller").GetComponent<MainMenuLight>();
    }

    public void Play(string level)
    {
        if (_light.isLightOn)
            SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        if (_light.isLightOn)
            Application.Quit();
    }
}
