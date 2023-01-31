 using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelsInterfaceGeneration : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private List<LevelInterface> levelInterfaces = new List<LevelInterface>();
    [SerializeField] private List<Transform> points = new List<Transform>();
    public void GenerateLevels(List<TileDependenciesLevelData> levelDataTiles)
    {
        levelInterfaces.Clear();

        for (int i = 0; i < levelDataTiles.Count; i++)
        {
            var tmp = Instantiate(levelPrefab, points[i].position, points[i].rotation, transform);
            var level = tmp.GetComponent<LevelInterface>();
            level.SetUpLevel(levelDataTiles[i]);

            Debug.Log(levelDataTiles[i].isReached);
            Debug.Log(levelDataTiles[i].nameLevel);

            levelInterfaces.Add(level);
        }

    }

    public void EnablePanels() {
        StartCoroutine(EnablePanelsEnumerator());
    }

    private IEnumerator EnablePanelsEnumerator() {
        for (int i = 1; i <= levelInterfaces.Count; i++)
        {
            if (levelInterfaces[i - 1].tileDependenciesLevelData.isReached)
            {
                levelInterfaces[i - 1].EnablePanel(1f);

                yield return new WaitForSeconds(levelInterfaces[i - 1].GetDuration());
            }
        }

        if (levelInterfaces[0] != null) {
            levelInterfaces[0].tileDependenciesLevelData.isReached = true;
            levelInterfaces[0].EnablePanel(1f);
        }
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