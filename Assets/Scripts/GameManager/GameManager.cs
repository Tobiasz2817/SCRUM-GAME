using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool AvaliableSpawnTiles { get; private set; }
    public static bool EndGame { get; private set; }

    public static event Action<bool> GameIsOver;

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
        GameIsOver?.Invoke(false);
        Debug.Log("Level is End");
    }
    private void EndWave(WaveDependencies obj)
    {
        if (!AvaliableSpawnTiles)
        {
            EndGame = true;
            GameIsOver?.Invoke(true);
            Debug.Log("IS OVER");
        }
    }

}
