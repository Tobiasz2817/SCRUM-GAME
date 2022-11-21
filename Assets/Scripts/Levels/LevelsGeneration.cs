using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsGeneration : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;

    private int countLevels = 28;
    
    public List<Level> CreateLevels()
    {
        var levelsOnSceneTmp = SaveManager.LoadDates<LevelInfo>(LevelsController.LEVEL_KEY_NAME,LevelsController.LEVEL_FILE_NAME);
        if (levelsOnSceneTmp != null && levelsOnSceneTmp.Count > 0)
            return ReadLevelsFromFile(levelsOnSceneTmp);
        
        var levelsOnScene = new List<Level>();
        GenerateLevels(ref levelsOnScene);

        return levelsOnScene;
    }

    private List<Level> ReadLevelsFromFile(List<LevelInfo> levelsOnScene)
    {
        Debug.Log("READ FROM FILE");
        
        var levelTmp = new List<Level>();
        for (int i = 1; i <= levelsOnScene.Count; i++)
        {
            var tmp  = Instantiate(levelPrefab, transform);
            var level = tmp.GetComponent<Level>();
            level.SetUpLevel(new LevelInfo() { nameLevel = levelsOnScene[i - 1].nameLevel, isReached = levelsOnScene[i - 1].isReached});
            if(levelsOnScene[i - 1].isReached)
                level.EnablePanel();

            Debug.Log(levelsOnScene[i - 1].isReached);
            Debug.Log(levelsOnScene[i - 1].nameLevel);
            
            levelTmp.Add(level);
        }

        return levelTmp;
    }

    private void GenerateLevels(ref List<Level> levelsOnScene)
    {
        Debug.Log("GENERATE LEVELS");
        
        for (int i = 1; i <= countLevels; i++)
        {
            var levelGameObject = Instantiate(levelPrefab, transform);
            var level = levelGameObject.GetComponent<Level>();
            level.SetUpLevel(new LevelInfo() { nameLevel = "Level " + i, isReached = false});

            levelsOnScene.Add(level);
        }
    }
}
