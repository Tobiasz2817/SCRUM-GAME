using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public List<Transform> spawnPositions;

    public Tile previousTale;

    public void TaleSetup(Tile previousTale)
    {
        this.previousTale = previousTale;
    }
}