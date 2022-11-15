using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    public const string LEVEL_FILE_NAME = "Levels";

    [SerializeField] private Button saveButton;
    [SerializeField] private LevelsGeneration _levelsGeneration;
    
    private Level[] levelsOnScene;
    
    private void Awake()
    {
        Level.OnClick += UnlockLevel;
    }

    private void UnlockLevel(Level obj)
    {
        for (int i = 0; i < levelsOnScene.Length; i++)
            if(levelsOnScene[i] == obj)
                if(i + 1 < levelsOnScene.Length)
                    if (!levelsOnScene[i + 1].IsGained)
                    {
                        if(i == 0)
                            levelsOnScene[i + 1].EnablePanelFade();
                        else
                            if(levelsOnScene[i - 1].IsGained)
                                levelsOnScene[i + 1].EnablePanelFade();
                    }
    }

    private void Start()
    {
        levelsOnScene = _levelsGeneration.CreateLevels();
        EnableFirstLevel();
    }

    private void OnEnable()
    {
        saveButton.onClick.AddListener(SaveLevels);
    }

    private void OnDisable()
    {
        saveButton.onClick.RemoveListener(SaveLevels);
    }
    private void EnableFirstLevel()
    {
        if (levelsOnScene != null && levelsOnScene.Length >= 1)
            levelsOnScene[0].EnablePanelFade();
    }
    
    public void SaveLevels()
    {
        List<bool> boolList = new List<bool>();
        foreach (var level in levelsOnScene)
        { 
            boolList.Add(level.IsGained);
        }
        SaveManager.SaveDates(boolList.ToArray(),LEVEL_FILE_NAME);
    }
}
