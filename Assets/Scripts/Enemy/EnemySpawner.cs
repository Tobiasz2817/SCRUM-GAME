using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private TilesController tilesController;

    [SerializeField] 
    private GameObject enemyPrefab;

    [SerializeField] 
    private float delayTime;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);

            foreach (var lastTile in tilesController.lastTiles)
            {
                foreach (var lastTileSpawnPoint in lastTile.tilePoints.spawnPositions)
                {
                    var enemy = Instantiate(enemyPrefab, lastTileSpawnPoint.position,lastTileSpawnPoint.rotation);
                    enemy.GetComponent<UnitAI>().SetUnit(tilesController.finallyPoint.position);
                }
            }
        }
    }
}
