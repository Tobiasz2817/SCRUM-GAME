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

    public Tile lastTile;

    [SerializeField] 
    public Transform finallyPoint;

    public static event Action<Transform[]> OnTileAdded;

    private void Start()
    {
        // Make First Tile
        SpawnTile(0,Vector3.zero, Quaternion.identity);
        finallyPoint = lastTile.finallyPosition != null ? lastTile.finallyPosition : finallyPoint;
    }

    private void OnEnable()
    {
        TileInterface.OnTileCreate += GenerateTransformNewTile;
    }

    private void OnDisable()
    {
        TileInterface.OnTileCreate -= GenerateTransformNewTile;
    }
    
    private void GenerateTransformNewTile()
    {
        SpawnTile(lastTile.newTilePlaceHolder);
    }

    private void SpawnTile(Vector3 pos, Quaternion rot)
    {
        var randomTile = Random.Range(1, tiles.Count);
        Vector3 spawnPos = lastTile != null ? lastTile.transform.position + pos : pos;
        //Quaternion spawnRot = lastTile != null ? new Quaternion(lastTile.transform.rotation.x + rot.x,lastTile.transform.rotation.y + rot.y,lastTile.transform.rotation.z + rot.z,lastTile.transform.rotation.w + rot.w) : rot;
        Quaternion spawnRot = lastTile != null ? rot : rot;
        lastTile = Instantiate(tiles[randomTile],spawnPos,spawnRot,transform).GetComponent<Tile>();
        lastTile.tileInterface.gameObject.SetActive(true);

        OnTileAdded?.Invoke(lastTile.path.TileSurfacePath());
    }
    private void SpawnTile(Transform newTilePos)
    {
        var randomTile = Random.Range(1, tiles.Count);
        
        var nextTile = Instantiate(tiles[randomTile],newTilePos.transform.position,Quaternion.identity,transform).GetComponent<Tile>();

        nextTile.gameObject.SetActive(false);

        int[] valuesRotate = {0, 90, 180, 270};
        foreach (var value in valuesRotate)
        {
            nextTile.transform.rotation = Quaternion.Euler(0, value - nextTile.transform.position.y, 0);
            
            if (Vector3.Distance(lastTile.spawnPositions[0].position, nextTile.finallyPosition.position) < 3f)
                break;
        }

        nextTile.gameObject.SetActive(true);
        
        lastTile = nextTile;
        lastTile.tileInterface.gameObject.SetActive(true);
        OnTileAdded?.Invoke(lastTile.path.TileSurfacePath());
    }
    private void SpawnTile(int index,Vector3 pos, Quaternion rot)
    {
        Vector3 spawnPos = lastTile != null ? lastTile.transform.position + pos : pos;
        Quaternion spawnRot = lastTile != null ? new Quaternion(lastTile.transform.rotation.x + rot.x,lastTile.transform.rotation.y + rot.y,lastTile.transform.rotation.z + rot.z,lastTile.transform.rotation.w + rot.w) : rot;
        lastTile = Instantiate(tiles[index],spawnPos,spawnRot,transform).GetComponent<Tile>();
        lastTile.tileInterface.gameObject.SetActive(true);

        OnTileAdded?.Invoke(lastTile.path.TileSurfacePath());
    }
}
