using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndless : MonoBehaviour
{
    private PlayerEndless _player;
    private const float Speed = 2f;
    private bool _isOnTopOfLight = false;
    public float enemyKillTime = 3f;
    public bool canHitPlayer = false;
    private void Start()
    {
        StartCoroutine(EnemyInvincibility());
        _player = GameObject.Find("Player").GetComponent<PlayerEndless>();
    }
    private void Update()
    {
        TriggerEnemyMovement();
        TriggerEnemyDamage();
    }

    private void TriggerEnemyDamage()
    {
        if (!_isOnTopOfLight || !canHitPlayer) return;
        enemyKillTime -= Time.deltaTime;
        if (enemyKillTime <= 0f)
            Destroy(this.gameObject);
    }

    private void TriggerEnemyMovement()
    {
        if (!canHitPlayer) return;
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

    private IEnumerator EnemyInvincibility()
    {
        canHitPlayer = false;
        yield return new WaitForSeconds(2f);
        canHitPlayer = true;
    }
}
