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
    }

    private void OnDisable()
    {
        TileDependencies.OnFullyDependencies -= DisableAccessibilitySpawningTile;
        UnitAI.ReachedGoal -= LoseLevel;
    }
    private void LoseLevel()
    {
        EndGame = true;
        Debug.Log("Level is End");
    }
    private void DisableAccessibilitySpawningTile()
    {
        AvaliableSpawnTiles = false;
    }
}
