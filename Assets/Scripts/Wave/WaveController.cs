using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public WaveDependencies waveDependencies;
    
    public EnemySpawner enemySpawner;
    public WaveInterface waveInterface;

    public static event Action OnWaveEnd;

    private void Start()
    {
        TileCreatingInterface.OnNewTileCreating += TileIsCreating;
    }
    
    private void OnDisable()
    {
        TileCreatingInterface.OnNewTileCreating -= TileIsCreating;
    }
    
    private async void TileIsCreating(Tile lastTiles, Transform newTilePlace)
    {
        waveDependencies.currentEnemiesByItteration += waveDependencies.IncreaseEnemiesByItteration;
        waveDependencies.currentDelayTime += waveDependencies.DecreaseDelayTime;
        
        
        for (int i = 0; i < waveDependencies.IncreaseEnemiesByWave; i++)
        {
            if (GameManager.EndGame) return;
            await enemySpawner.SpawnEnemies(waveDependencies);
        }
        
        OnWaveEnd?.Invoke();
    }
}

[Serializable]
public class WaveDependencies
{
    public float DecreaseDelayTime = -1;
    public int IncreaseEnemiesByItteration = 1;
    public int IncreaseEnemiesByWave = 6;
    
    public float currentDelayTime = 8;
    public int currentEnemiesByItteration = 2;
    public int currentEnemiesByWave = 6;
}
