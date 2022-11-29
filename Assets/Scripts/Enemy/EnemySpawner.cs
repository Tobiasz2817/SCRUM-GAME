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
            var enemy = Instantiate(enemyPrefab, tilesController.lastTiles[0].spawnPositions[0].position,tilesController.lastTiles[0].spawnPositions[0].rotation);
            enemy.GetComponent<UnitAI>().SetUnit(tilesController.finallyPoint.position);
        }
    }
}
