using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaGenerator : MonoBehaviour
{
    private LevelStats levelStats;
    private void Awake()
    {
        levelStats = FindObjectOfType<LevelStats>();
        
    }
    void Start()
    {
        Bought();
    }
    void Bought()
    {
        levelStats.manaGrowth += 1;
    }
    void Sold()
    {
        levelStats.manaGrowth -= 1;
    }
}
