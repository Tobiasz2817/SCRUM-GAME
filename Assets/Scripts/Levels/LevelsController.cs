using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    public const string LEVEL_FILE_NAME = "Levels";
    public const string LEVEL_KEY_NAME = "Levels";

    [SerializeField] private Button saveButton;
    [SerializeField] private LevelsGeneration _levelsGeneration;
    
    private List<Level> levelsOnScene;
    
    private void Awake()
    {
        Level.OnClick += UnlockLevel;
    }

    private void UnlockLevel(Level obj)
    {
        for (int i = 1; i <= levelsOnScene.Count; i++)
        {
            if (levelsOnScene[i - 1] == obj)
            {
                levelsOnScene[i].EnablePanel();
                break;
            }
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
        if (levelsOnScene != null && levelsOnScene.Count >= 1)
            levelsOnScene[0].EnablePanel();
    }
    
    public void SaveLevels()
    {
        List<LevelInfo> levelInfos = new List<LevelInfo>();
        foreach (var level in levelsOnScene)
            levelInfos.Add(level.levelInfo);

        SaveManager.SaveDates(LEVEL_KEY_NAME,levelInfos,LEVEL_FILE_NAME, ModificationType.Replaced);
    }
}
