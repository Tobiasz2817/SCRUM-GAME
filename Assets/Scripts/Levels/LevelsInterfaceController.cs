using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsInterfaceController : MonoBehaviour
{
    /*public const string LEVEL_FILE_NAME = "Levels";
    public const string LEVEL_KEY_NAME = "Levels";*/
    
    [SerializeField] private LevelsInterfaceGeneration _levelsGeneration;
    
    [SerializeField]
    private List<TileDependenciesLevelData> levelDataTiles;

    private void OnEnable()
    {
        LevelInterface.OnClick += StartGame;
    }
    
    private void Start()
    {
        _levelsGeneration.GenerateLevels(levelDataTiles);
        _levelsGeneration.EnablePanels();
    }
    
    private void StartGame(LevelInterface level)
    {
        TileDependenciesHandler.Instance.currentDependencies = level.tileDependenciesLevelData;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
