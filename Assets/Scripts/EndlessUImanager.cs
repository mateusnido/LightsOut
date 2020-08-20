using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessUImanager : MonoBehaviour
{
    public Text timeText;
    private float _time;
    public Text highScoreText;

    private void Update()
    {
        timeText.text = (_time.ToString(string.Empty));
    }

    private void Start()
    {
        _time = 0f;
        StartCoroutine(AddTime());
        highScoreText.text = "BEST: " + PlayerPrefs.GetFloat("HighScore", 0);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game_Endless");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator AddTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            _time += 0.05f;
            if (_time > PlayerPrefs.GetFloat("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", _time);
                highScoreText.text = "BEST: " + _time;
            }
        }
    }
}
