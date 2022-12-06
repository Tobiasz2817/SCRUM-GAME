using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public WaveDependencies waveDependencies;
    
    public EnemySpawner enemySpawner;
    //public WaveInterface waveInterface;
    public static event Action<WaveDependencies> OnWaveEnd;

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
        await Task.Delay(1000);
        
        waveDependencies.IncreaseValuesByWave();
        waveDependencies.IncreaseWave();

        for (int i = 0; i < waveDependencies.currentEnemiesByWave; i++)
        {
            if (GameManager.EndGame) return;
            await enemySpawner.SpawnEnemies(waveDependencies);
        }
        
        OnWaveEnd?.Invoke(waveDependencies);
    }
}

[Serializable]
public class WaveDependencies
{
    [Header("Wave Increasing Dependencies")]    
    public float DecreaseDelayTime = -1;
    public int IncreaseEnemiesByItteration = 1;
    public int IncreaseEnemiesByWave = 3;
    
    public int countWaves = 3;
    
    [Header("Start Wave Dependencies")]   
    public float currentDelayTime = 8;
    public int currentEnemiesByItteration = 2;
    public int currentEnemiesByWave = 6;

    [HideInInspector]
    public int currentWave = 0;

    public void IncreaseValuesByWave()
    {
        currentEnemiesByItteration += IncreaseEnemiesByItteration;
        currentEnemiesByWave += IncreaseEnemiesByWave;
        currentDelayTime += DecreaseDelayTime;
    }
    public void IncreaseWave()
    {
        currentWave++;
    }
}
