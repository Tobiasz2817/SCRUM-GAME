
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileSpawn : MonoBehaviour
{
    [SerializeField]
    private List<Tile> tiles = new List<Tile>();
    
    public List<Tile> lastTiles = new List<Tile>();
    
    public static event Action<Transform[]> OnTileAdded;
    
    public Tile SpawnTile(int tileIndex,Tile lastTile,Vector3 newTilePos)
    {
        var nextTile = Instantiate(tiles[tileIndex],newTilePos,Quaternion.identity,transform).GetComponent<Tile>();

        SetSuitableTileRotation(nextTile,lastTile);
        
        if (lastTiles.Contains(lastTile) && lastTile.roads == CountRoads.Single)
            lastTiles.Remove(lastTile);

        lastTiles.Add(nextTile);
        
        
        OnTileAdded?.Invoke(this.lastTiles[(int)lastTiles.Count - 1].path.TileSurfacePath());
        return nextTile;
    }

    private void SetSuitableTileRotation(Tile nextTile,Tile lastTile)
    {
        if (!lastTile) return;
        
        int[] valuesRotate = {0, 90, 180, 270};

        Transform spawnPoint = lastTile.tilePoints.GetClosestsSpawnPoint(nextTile.tilePoints.finallyPosition);
        
        foreach (var value in valuesRotate)
        {
            nextTile.transform.rotation = Quaternion.Euler(0, value - nextTile.transform.position.y, 0);

            if (Vector3.Distance(spawnPoint.position, nextTile.tilePoints.finallyPosition.position) < 3f)
                break;
        }
    }

    public Transform GetFinallyPoint()
    {
        var finallyPosition = lastTiles[0].tilePoints.finallyPosition;
        if (finallyPosition != null)
            return finallyPosition;

        return null;
    }

    public List<Tile> GetListTiles()
    {
        return tiles;
    }
}
