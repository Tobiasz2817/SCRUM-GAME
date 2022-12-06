using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private TilesController tilesController;

    [SerializeField] 
    private GameObject enemyPrefab;

    private bool startCheckEnemies = false;
    private bool isWaveEnd = false;
    public static event Action OnEnemiesDown;

    private void OnEnable()
    {
        WaveController.OnWaveEnd += WaveEnd;
    }
    
    public void OnDisable()
    {
        WaveController.OnWaveEnd -= WaveEnd;
    }

    public async Task SpawnEnemies(WaveDependencies waveDependencies)
    {
        foreach (var lastTile in tilesController.tileSpawn.lastTiles)
        {
            foreach (var lastTileSpawnPoint in lastTile.tilePoints.spawnPositions)
            {
                for (int i = 0; i < waveDependencies.currentEnemiesByItteration; i++)
                {
                    if (GameManager.EndGame) return;

                    var enemy = Instantiate(enemyPrefab, lastTileSpawnPoint.position,lastTileSpawnPoint.rotation);
                    enemy.GetComponent<UnitAI>().SetUnit(tilesController.finallyPoint.position);
                }
            }
        }
        startCheckEnemies = true;
        await Task.Delay((int)(waveDependencies.currentDelayTime * 1000));
    }

    private void Update()
    {
        if (startCheckEnemies)
        {
            InvokeRepeating(nameof(HearthBeatEnemiesCheck),0f,2f);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var enemies = FindObjectsOfType<UnitAI>();
            foreach (var enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            Debug.Log("Invoke");
        }
    }

    private void HearthBeatEnemiesCheck()
    {
        var enemies = GameObject.FindWithTag("Enemy");
        if (enemies == null && isWaveEnd)
        {
            if (!GameManager.EndGame)
                OnEnemiesDown?.Invoke();

            CancelInvoke(nameof(HearthBeatEnemiesCheck));
            startCheckEnemies = false;
            isWaveEnd = false;
        }
    }
    private void WaveEnd(WaveDependencies obj)
    {
        isWaveEnd = true;
    }

}
