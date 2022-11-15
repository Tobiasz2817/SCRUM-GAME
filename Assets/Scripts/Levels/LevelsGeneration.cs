using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsGeneration : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;

    private int countLevels = 28;
    
    public Level[] CreateLevels()
    {
        var levelsOnSceneTmp = SaveManager.LoadDates<bool>(LevelsController.LEVEL_FILE_NAME);
        if (levelsOnSceneTmp != null && levelsOnSceneTmp.Count > 0)
            return ReadLevelsFromFile(levelsOnSceneTmp.ToArray());
        

        var levelsOnScene = new Level[countLevels];
        GenerateLevels(ref levelsOnScene);

        return levelsOnScene;
    }

    private Level[] ReadLevelsFromFile(bool[] levelsOnScene)
    {
        Debug.Log("READ FROM FILE");
        
        var levelTmp = new Level[levelsOnScene.Length];
        for (int i = 1; i <= levelsOnScene.Length; i++)
        {
            var tmp  = Instantiate(levelPrefab, transform);
            var level = tmp.GetComponent<Level>();
            level.SetUpLevel("Level " + i);
            if(levelsOnScene[i - 1])
                level.EnablePanelFade();

            levelTmp[i - 1] = level;
        }

        return levelTmp;
    }

    private void GenerateLevels(ref Level[] levelsOnScene)
    {
        Debug.Log("GENERATE LEVELS");
        
        for (int i = 1; i <= countLevels; i++)
        {
            var levelGameObject = Instantiate(levelPrefab, transform);
            var level = levelGameObject.GetComponent<Level>();
            level.SetUpLevel("Level " + i);

            levelsOnScene[i - 1] = level;
        }
    }
}
