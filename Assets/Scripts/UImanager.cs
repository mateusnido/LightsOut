using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text powerupTimeText;
    private Player _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        DisplayPowerUpTime();
        if (_player.isGameOver)
            Destroy(powerupTimeText);
    }

    private void DisplayPowerUpTime()
    {
        if (_player.powerUpWaitTime > 0f)
            powerupTimeText.text = ("POWERUP: " + _player.powerUpWaitTime);
        else if (_player.powerUpWaitTime <= 0f && _player.isPowerUpUsed == false)
            powerupTimeText.text = ("POWERUP: READY");
        else if (_player.isPowerUpUsed)
            powerupTimeText.text = ("POWERUP: USED");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game#1");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Game#4");
    }

    public void LoadLevel10()
    {
        SceneManager.LoadScene("Game#10");
    }

    public void LoadLevel17()
    {
        SceneManager.LoadScene("Game#17");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
