using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private const float Speed = 2f;
    private bool _isOnTopOfLight = false;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        Cursor.visible = true;
    }
    private void Update()
    {
        if (_isOnTopOfLight) return;
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        RotateTheEnemy();
    }
    private void RotateTheEnemy()
    {
        var vectorToTarget = _player.transform.position - transform.position;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Speed);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerLight"))
        {
            _isOnTopOfLight = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerLight"))
        {
            _isOnTopOfLight = false;
        }
    }
}
