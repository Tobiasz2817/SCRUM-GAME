using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile",menuName = "TileDependenciesLevel")]

[Serializable]
public class TileDependenciesLevelData : ScriptableObject
{
    public bool isReached;
    public string nameLevel;
    
    public int CountOfDoubleTile;
    public int CountOfTripleTile;
    public int CountOfSingleTile;
}
