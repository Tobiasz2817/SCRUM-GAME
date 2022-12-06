using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public TilePath path;
    [SerializeField] public TileInterface tileInterface;
    [SerializeField] public TileMoveToPoints tilePoints;
    [SerializeField] public CountRoads roads;
}



public enum CountRoads
{
    Single = 1,
    Double = 2,
    Triple = 3
}