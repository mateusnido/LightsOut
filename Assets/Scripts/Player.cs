using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 _move;
    public float moveSpeed;
    public GameObject playerLight;
    public bool isLightOn = false;
    public GameObject gameOverScreen;
    public Camera cam;
    public bool isGameOver;
    public GameObject tutorialText;
    public bool isAllowedToHavePowerUp;
    private bool _hasPowerUp;
    public GameObject enemyHolder;
    public GameObject explosionPowerUp;
    public float powerUpWaitTime;
    private AudioManager _manager;
    public bool isPowerUpUsed = false;
    private void Start()
    {
        _manager = FindObjectOfType<AudioManager>();
        isPowerUpUsed = false;
        _hasPowerUp = false;
        powerUpWaitTime = 3f;
        tutorialText.SetActive(true);
        isGameOver = false;
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        playerLight.SetActive(true);
        isLightOn = true;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (isGameOver) return;
        MoveLight();
        SwitchLight();
        ChargePowerUp();
        UsePowerUp();

        moveSpeed = (isLightOn ? 4f : 7f);
    }

    private void MoveLight()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerLight.transform.position = mousePos;
    }

    private void ChargePowerUp()
    {
        if (!isLightOn && isAllowedToHavePowerUp && powerUpWaitTime > 0f)
            powerUpWaitTime -= Time.deltaTime;
        if (powerUpWaitTime <= 0f)
            _hasPowerUp = true;
    }

    private void UsePowerUp()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse1) || !_hasPowerUp || isPowerUpUsed) return;
        Instantiate(explosionPowerUp, transform.position, Quaternion.identity);
        Destroy(enemyHolder);
        isPowerUpUsed = true;
    }

    private void FixedUpdate()
    {
        _move.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        _move.y = Input.GetAxisRaw("Vertical") * moveSpeed;
        transform.Translate(_move * Time.deltaTime);
    }

    private void SwitchLight()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        _manager.Play("Light On");
        playerLight.SetActive(!isLightOn);
        isLightOn = !isLightOn;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            GameOver();
    }

    private void GameOver()
    {
        playerLight.SetActive(true);
        playerLight.transform.position = transform.position;
        tutorialText.SetActive(false);
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        Cursor.visible = true;
    }
}
