﻿using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Transform SpawnPoint;
    public Text WaveCountdown;

    [SerializeField] Wave[] _waves;

    public float WaveGapDelay = 3.5f;

    private float _countdown = 2f;
    private int _waveIndex = 0;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
    {

        if (EnemiesAlive > 0)
            return; 

        if (_waveIndex == _waves.Length && EnemiesAlive == 0) {

            PlayerStats.RoundsSurvived++;
            PlayerStats.Die();
            return;

        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        WaveCountdown.text = string.Format("{0}{1}.{2}{3}", (int)(_countdown / 10), (int)(_countdown) % 10,
                                                            (int)(_countdown * 10) % 10, (int)(_countdown * 100) % 10);

        if (_countdown <= 0f) {

            PlayerStats.RoundsSurvived++;
            StartCoroutine(SpawnWave());
            _countdown = WaveGapDelay;

        } 
    }

    // use IEnumerator so that enemies won't spawn inside themselves
    IEnumerator SpawnWave()
    { 

        for (int k = 0; k < _waves[_waveIndex].Enemies.Length; k++) {

            for (int i = 0; i < _waves[_waveIndex].nEnemies[k]; i++) {

                SpawnEnemy(_waves[_waveIndex].Enemies[k]);
                yield return new WaitForSeconds(1f / _waves[_waveIndex].nSpawnRate[k]); 

            }

        }  

        _waveIndex += 1;

    }

    void SpawnEnemy(GameObject enemy)
    {

        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation); 
        EnemiesAlive++;

    }

}
