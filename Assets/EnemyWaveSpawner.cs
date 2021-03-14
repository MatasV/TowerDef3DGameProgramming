using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaveSpawner : MonoBehaviour
{
    public StageEnemyData stageEnemyData;

    public SharedBool playerWon;
    public SharedBool playerLost;
    
    public Transform spawnLocation;
    public Transform endLocation;
    
    public float enemySpawnRate;
    public float timeBetweenWaves;

    private int currentEnemyIndex = 0;
    private int currentWaveIndex = 0;
    
    private int enemyCount = 0;
    
    private bool waveSpawningDone = false;
    private bool enemiesDead = false;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnNextEnemy), timeBetweenWaves, 1/enemySpawnRate);
    }

    private void Awake()
    {
        playerWon.Value = false;
    }
    private void SpawnNextEnemy()
    {
        if (playerLost)
        {
            CancelInvoke();
            return;
        }
        var clone = Instantiate(stageEnemyData.waves[currentWaveIndex].enemies[currentEnemyIndex],
            spawnLocation.position, Quaternion.identity);
        var navigator = clone.GetComponent<NavMeshAgent>();

        enemyCount++;
        navigator.SetDestination(endLocation.position);

        var enemy = clone.GetComponent<Enemy>();
        enemy.enemyWaveSpawner = this;
        
        currentEnemyIndex++;
        if (currentEnemyIndex >= stageEnemyData.waves[currentWaveIndex].enemies.Length)
        {
            currentEnemyIndex = 0;
            currentWaveIndex++;

            if (currentWaveIndex >= stageEnemyData.waves.Length)
            {
                StageComplete();
                return;
            }
            
            CancelInvoke();
            InvokeRepeating(nameof(SpawnNextEnemy), timeBetweenWaves, 1/enemySpawnRate);
        }
    }

    public void EnemyDead()
    {
        enemyCount--;
        if (enemyCount <= 0) EnemiesDead();
    }

    private void EnemiesDead()
    {
        enemiesDead = true;
        if (waveSpawningDone) Win();
        Debug.Log("All enemies Dead!");
    }
    private void StageComplete()
    {
        CancelInvoke();
        waveSpawningDone = true;
        if(enemiesDead) Win();
        Debug.Log("Stage Spawning Done!");
    }

    private void Win()
    {
        if (!playerLost) playerWon.Value = true;
    }
}
