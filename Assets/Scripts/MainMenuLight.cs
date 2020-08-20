using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLight : MonoBehaviour
{
    public GameObject flashLight;
    public bool isLightOn = false;
    public Camera cam;
    private AudioManager _manager;
    private void Start()
    {
        _manager = FindObjectOfType<AudioManager>();
        flashLight.SetActive(false);
    }

    private void Update()
    {
        MoveMenuLight();
        if (Input.GetButtonDown("Fire1"))
            StartCoroutine(SwitchLight());
    }

    private void MoveMenuLight()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    private IEnumerator SwitchLight()
    {
        _manager.Play("Light On");
        flashLight.SetActive(!isLightOn);
        yield return new WaitForSeconds(0.2f);
        isLightOn = !isLightOn;
    }
}
