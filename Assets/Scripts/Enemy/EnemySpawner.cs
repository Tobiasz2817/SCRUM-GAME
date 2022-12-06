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
    public static event Action OnEnemiesDown;
    
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
    }

    private void HearthBeatEnemiesCheck()
    {
        var enemies = GameObject.FindWithTag("Enemy");
        if (enemies == null)
        {
            OnEnemiesDown?.Invoke();
            CancelInvoke(nameof(HearthBeatEnemiesCheck));
            startCheckEnemies = false;
        }
    }
}
