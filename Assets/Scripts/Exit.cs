using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private int doorNumber;

    private void Start()
    {
        doorNumber += 2;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (doorNumber == 20)
            SceneManager.LoadScene("End");
        else if (doorNumber == 23)
            SceneManager.LoadScene("Main Menu");
        else
            SceneManager.LoadScene("Game#" + doorNumber);
    }
}
