using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    
    public float WaveGapDelay = 5.5f;

    private float _countdown = 2f;
    private int _waveIndex = 0;

    void Update()
    {

        _countdown -= Time.deltaTime;

        if (_countdown <= 0f) {

            StartCoroutine(SpawnWave());
            _countdown = WaveGapDelay;

        }

    }

    // use IEnumerator so that enemies won't spawn inside themselves
    IEnumerator SpawnWave()
    {

        _waveIndex += 1;
        int nEnemies = Math.Max(1, (int)(_waveIndex * 1.2f));

        for (int i = 0; i < nEnemies; i++) {

            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);

        }

    }

    void SpawnEnemy()
    {

        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);

    }

}
