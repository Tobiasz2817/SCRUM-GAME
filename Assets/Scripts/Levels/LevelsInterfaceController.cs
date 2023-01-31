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
    
    private void Start() {
        var x = SaveManager.LoadDates<bool>("LevelData", "LevelDataFile");
        if (x.Count == 0) 
            SetToFile();
        else
            for (int i = 0; i < x.Count; i++) {
                levelDataTiles[i].isReached = x[i];
                Debug.Log(x.Count);
            }
            
        
        
        _levelsGeneration.GenerateLevels(levelDataTiles);
        _levelsGeneration.EnablePanels();
        
        SetToFile();
    }
    
    private void StartGame(LevelInterface level)
    {
        TileDependenciesHandler.Instance.currentDependencies = level.tileDependenciesLevelData;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetToFile() {
        var boolTmp = new List<bool>();
        foreach (var var in levelDataTiles)
            boolTmp.Add(var.isReached);
        
        SaveManager.SaveDates("LevelData",boolTmp,"LevelDataFile",ModificationType.Replaced);
    }
}
