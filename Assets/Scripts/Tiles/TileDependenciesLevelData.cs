using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile",menuName = "TileDependenciesLevel")]
public class TileDependenciesLevelData : ScriptableObject
{
    public int CountOfDoubleTile;
    public int CountOfTripleTile;
    public int CountOfSingleTile;
}
