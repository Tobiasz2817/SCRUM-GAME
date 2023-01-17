using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private TilesController tilesController;

    [SerializeField] 
    private GameObject enemyPrefab;

    private CardParemeters cardParameters;

    private bool startCheckEnemies = false;
    private bool isWaveEnd = false;
    public static event Action OnEnemiesDown;
    public static event Action OnOverGame;

    private void OnEnable()
    {
        WaveController.OnWaveEnd += WaveEnd;
        CardEventsHandler.OnModificateHealth += SetImplant;
        CardEventsHandler.OnModificateMovement += SetImplant;
    }

    public void OnDisable()
    {
        WaveController.OnWaveEnd -= WaveEnd;
        CardEventsHandler.OnModificateHealth -= SetImplant;
        CardEventsHandler.OnModificateMovement -= SetImplant;
    }

    public async Task SpawnEnemies(WaveDependencies waveDependencies)
    {
        foreach (var lastTile in tilesController.tileSpawn.lastTiles)
        {
            foreach (var lastTileSpawnPoint in lastTile.tilePoints.spawnPositions)
            {
                for (int i = 0; i < waveDependencies.currentEnemiesByItteration; i++)
                {
                    if (GameManager.EndGame) return;
                    
                    var enemy = Instantiate(enemyPrefab, lastTileSpawnPoint.position,Quaternion.Euler(lastTileSpawnPoint.position - tilesController.finallyPoint.position));
                    var unitAI = enemy.GetComponent<UnitAI>();
                    unitAI.SetUnitDestination(tilesController.finallyPoint.position);
                    unitAI.effects.TurnDissolves(1);
                    
                    
                    if(cardParameters == null) continue;
                    unitAI.SetUnitImplants(cardParameters);
                }
            }
        }
        startCheckEnemies = true;
        await Task.Delay((int)(waveDependencies.currentDelayTime * 1000));
    }

    private void Update()
    {
        if (startCheckEnemies)
        {
            InvokeRepeating(nameof(HearthBeatEnemiesCheck),0f,2f);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var enemies = FindObjectsOfType<UnitAI>();
            foreach (var enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            Debug.Log("Invoke");
        }
    }

    private void HearthBeatEnemiesCheck()
    {
        var enemies = GameObject.FindWithTag("Enemy");
        if (enemies == null && isWaveEnd)
        {
            if (GameManager.AvaliableSpawnTiles)
                OnEnemiesDown?.Invoke();
            else
                OnOverGame?.Invoke();

            CancelInvoke(nameof(HearthBeatEnemiesCheck));
            startCheckEnemies = false;
            isWaveEnd = false;
        }
    }

    private void WaveEnd(WaveDependencies obj) => isWaveEnd = true;
    private void SetImplant(CardParemeters cardParameters) => this.cardParameters = cardParameters;
}
