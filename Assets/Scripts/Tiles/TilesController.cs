using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TilesController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tiles = new List<GameObject>();

    public List<Tile> lastTiles;

    [SerializeField] 
    public Transform finallyPoint;

    public static event Action<Transform[]> OnTileAdded;

    private void Start()
    {
        // Make First Tile
        SpawnTile(0,Vector3.zero, Quaternion.identity);
        finallyPoint = lastTiles[0].tilePoints.finallyPosition != null ? lastTiles[0].tilePoints.finallyPosition : finallyPoint;
    }

    private void OnEnable()
    {
        TileCreatingInterface.OnNewTileCreating += SpawnTile;
    }

    private void OnDisable()
    {
        TileCreatingInterface.OnNewTileCreating -= SpawnTile;
    }

    private void SpawnTile(Tile lastTile,Transform newTilePos)
    {
        var randomTile = Random.Range(1, tiles.Count);
        
        var nextTile = Instantiate(tiles[randomTile],newTilePos.transform.position,Quaternion.identity,transform).GetComponent<Tile>();

        nextTile.gameObject.SetActive(false);

        SetSuitableTileRotation(nextTile,lastTile);

        nextTile.gameObject.SetActive(true);

        if (lastTiles.Contains(lastTile) && lastTile.countNewPath <= 1)
            lastTiles.Remove(lastTile);

        lastTiles.Add(nextTile);
        
        OnTileAdded?.Invoke(this.lastTiles[(int)lastTiles.Count - 1].path.TileSurfacePath());
    }
    private void SpawnTile(int index,Vector3 pos, Quaternion rot)
    {
        lastTiles.Add(Instantiate(tiles[index],tiles[index].transform.position,Quaternion.identity,transform).GetComponent<Tile>());

        OnTileAdded?.Invoke(lastTiles[(int)lastTiles.Count - 1].path.TileSurfacePath());
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
}
