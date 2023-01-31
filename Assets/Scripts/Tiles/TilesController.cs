using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TilesController : MonoBehaviour
{
    public Transform finallyPoint;
    
    public TileDependencies tileDependencies;
    public TileSpawn tileSpawn;
    public EndGameInterface endGameInterface;

    public List<Tile> environmentTiles = new List<Tile>();

    [SerializeField]
    private TileDependenciesLevelData tileDependenciesLevelData;

    private bool IsGameOver = false;
    private void Start()
    {
        CreateTileDependecies();
        FirstTileCreate();
    }

    private void OnEnable()
    {
        TileCreatingInterface.OnNewTileCreating += SpawnTile;
        TileDependencies.OnFullyDependencies += DisableInterface;
        EnemySpawner.OnEnemiesDown += EnableInterface;
        EnemySpawner.OnOverGame += IsOver;
        UnitAI.ReachedGoal += LoseLevel;
    }
    private void OnDisable()
    {
        TileCreatingInterface.OnNewTileCreating -= SpawnTile;
        TileDependencies.OnFullyDependencies -= DisableInterface;
        EnemySpawner.OnEnemiesDown -= EnableInterface;
        EnemySpawner.OnOverGame -= IsOver;
        UnitAI.ReachedGoal -= LoseLevel;
    }

    public async void LoseLevel() {
        if (IsGameOver) return;

        Debug.Log("YOU LOSE");
        Debug.Log("Back to lobby...");
        endGameInterface.EnableEndInterface("You Failed :(");
        IsGameOver = true;
        await Task.Delay(5000);

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private async void IsOver()
    {
        Debug.Log("CONGRATS YOU WIN");
        Debug.Log("Back to lobby...");
        endGameInterface.EnableEndInterface("Well done, you passed the level :)");
        await Task.Delay(5000);
        
        Time.timeScale = 1;
        SetToFile();
        tileDependenciesLevelData.isReached = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void SetToFile() {
        var currentDataFile = SaveManager.LoadDates<bool>("LevelData","LevelDataFile");

        for (int i = 1; i < currentDataFile.Count; i++) {
            if (currentDataFile[i - 1] && !currentDataFile[i]) {
                currentDataFile[i] = true;
                break;
            }
        }

        SaveManager.SaveDates("LevelData",currentDataFile,"LevelDataFile",ModificationType.Replaced);
    }


    private void SpawnTile(Tile lastTile, Transform newTilePlace)
    {
        if (!GameManager.AvaliableSpawnTiles || GameManager.EndGame) return;
        
        int randomIndex = tileDependencies.GetTileIndex();
        environmentTiles.Add(tileSpawn.SpawnTile(randomIndex,lastTile,newTilePlace.position));

        //tileDependencies.DependenciesAreFully();
        
        DisableInterface();
    }
    private void DisableInterface()
    {
        foreach (var tile in environmentTiles)
            tile.tileInterface.gameObject.SetActive(false);
    }
    private void EnableInterface()
    {
        foreach (var tile in environmentTiles)
            tile.tileInterface.gameObject.SetActive(true);
    }

    private void CreateTileDependecies()
    {
        tileDependenciesLevelData = TileDependenciesHandler.Instance != null ? TileDependenciesHandler.Instance.currentDependencies : tileDependenciesLevelData;
        tileDependencies = new TileDependencies(tileDependenciesLevelData,tileSpawn.GetListTiles());
    }

    private void FirstTileCreate()
    {
        environmentTiles.Add(tileSpawn.SpawnTile(tileDependencies.GetTileIndex(CountRoads.Single),null,Vector3.zero));
        finallyPoint = tileSpawn.GetFinallyPoint();
    }
}
