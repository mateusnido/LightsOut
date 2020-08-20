using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEndless : MonoBehaviour
{
    private Vector2 _move;
    public float moveSpeed;
    public GameObject playerLight;
    public bool isLightOn = false;
    public GameObject gameOverScreen;
    public Camera cam;
    public bool isGameOver;
    private AudioManager _manager;
    private void Start()
    {
        _manager = FindObjectOfType<AudioManager>();
        isGameOver = false;
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        playerLight.SetActive(true);
        isLightOn = true;
        Cursor.visible = false;
    }

    private void Update()
    {
        MoveLight();
        if (Input.GetButtonDown("Fire1"))
            SwitchLight();
    }

    private void MoveLight()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (!isGameOver)
            playerLight.transform.position = mousePos;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _move.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        _move.y = Input.GetAxisRaw("Vertical") * moveSpeed;

        transform.Translate(_move * Time.deltaTime);
    }

    private void SwitchLight()
    {
        _manager.Play("Light On");
        playerLight.SetActive(!isLightOn);
        isLightOn = !isLightOn;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        if (other.GetComponent<EnemyEndless>().canHitPlayer)
            GameOver();
    }

    private void GameOver()
    {
        playerLight.transform.position = transform.position;
        isGameOver = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
}
