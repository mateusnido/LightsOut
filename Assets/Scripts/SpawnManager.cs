using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public float enemySpawnWaitTime;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(4f);
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnWaitTime);
            SpawnEnemy();
            if (enemySpawnWaitTime >= 1)
                enemySpawnWaitTime -= 0.05f;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f)), Quaternion.identity);
    }
}
