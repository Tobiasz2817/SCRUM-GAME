using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsInterfaceGeneration : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;
    
    List<LevelInterface> levelInterfaces = new List<LevelInterface>();
    public void GenerateLevels(List<TileDependenciesLevelData> levelDataTiles)
    {
        levelInterfaces.Clear();

        foreach (var levelData in levelDataTiles)
        {
            var tmp  = Instantiate(levelPrefab, transform);
            var level = tmp.GetComponent<LevelInterface>();
            level.SetUpLevel(levelData);
            
            Debug.Log(levelData.isReached);
            Debug.Log(levelData.nameLevel);
            
            levelInterfaces.Add(level);
        }
    }

    public void EnablePanels()
    {
        LevelInterface lastReachedPanel = levelInterfaces[0];
        for (int i = 1; i <= levelInterfaces.Count; i++)
        {
            if (levelInterfaces[i - 1].tileDependenciesLevelData.isReached)
            {
                levelInterfaces[i - 1].EnablePanel();
                lastReachedPanel = levelInterfaces[i];
            }
        }

        lastReachedPanel.EnablePanel();
    }
}
/*
var levelsFromFile = SaveManager.LoadDates<TileDependenciesLevelData>(LevelsInterfaceController.LEVEL_KEY_NAME,LevelsInterfaceController.LEVEL_FILE_NAME);

if (levelsFromFile != null && levelsFromFile.Count > 0)
{
    Debug.Log("DATES ARE EXSIST");
    return GenerateLevels(levelsFromFile);
}
*/