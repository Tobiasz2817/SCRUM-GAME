using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaBank : MonoBehaviour
{
    private LevelStats levelStats;
    private void Awake()
    {
        levelStats = FindObjectOfType<LevelStats>();
    }
    private void Start()
    {
        Bought();
    }
    void Bought()
    {
        levelStats.maxMana += 50;
    }
    void Sold()
    {
        levelStats.maxMana -= 50;
    }
}
