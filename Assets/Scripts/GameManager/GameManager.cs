using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool AvaliableSpawnTiles { get; private set; }
    public static bool EndGame { get; private set; }

    private void Start()
    {
        AvaliableSpawnTiles = true;
        EndGame = false;
    }

    private void OnEnable()
    {
        TileDependencies.OnFullyDependencies += DisableAccessibilitySpawningTile;
        UnitAI.ReachedGoal += LoseLevel;
        WaveController.OnWaveEnd += EndWave;
    }
    private void OnDisable()
    {
        TileDependencies.OnFullyDependencies -= DisableAccessibilitySpawningTile;
        UnitAI.ReachedGoal -= LoseLevel;
        WaveController.OnWaveEnd -= EndWave;
    }

    private void DisableAccessibilitySpawningTile()
    {
        AvaliableSpawnTiles = false;
    }
    private void LoseLevel()
    {
        EndGame = true;
        Debug.Log("Level is End");
    }
    private void EndWave(WaveDependencies obj)
    {
        if (obj.currentWave > obj.countWaves)
            EndGame = true;
    }

}
