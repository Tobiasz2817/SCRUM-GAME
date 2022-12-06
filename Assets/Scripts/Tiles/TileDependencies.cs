
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileDependencies
{
    public Dictionary<CountRoads, List<int>> dictDependencies = new Dictionary<CountRoads, List<int>>();
    public Dictionary<CountRoads, int> currentAvailables = new Dictionary<CountRoads, int>();
    public TileDependenciesLevelData dependenciesLevelData;

    public static event Action OnFullyDependencies;
    public TileDependencies(TileDependenciesLevelData dependenciesLevelData, List<Tile> tilesList)
    {
        this.dependenciesLevelData = dependenciesLevelData;
        this.CreateAvailablesRoads(dependenciesLevelData);
        this.CreateDictionaryDependencies(tilesList);
    }

    private void CreateAvailablesRoads(TileDependenciesLevelData dependenciesLevelData)
    {
        currentAvailables.Add(CountRoads.Single,dependenciesLevelData.CountOfSingleTile);
        currentAvailables.Add(CountRoads.Double,dependenciesLevelData.CountOfDoubleTile);
        currentAvailables.Add(CountRoads.Triple,dependenciesLevelData.CountOfTripleTile);
    }
    private void CreateDictionaryDependencies(List<Tile> tilesList)
    {
        tilesList.Sort((tile1, tile2) => tile1.roads.CompareTo(tile2.roads));

        for (int i = 0; i < tilesList.Count; i++)
        {
            if(dictDependencies.ContainsKey(tilesList[i].roads))
                dictDependencies[tilesList[i].roads].Add(i);
            else 
                dictDependencies.Add(tilesList[i].roads, new List<int>(){i});
        }
    }

    public int GetTileIndex()
    {
        int randomDependecies = Random.Range(1, ((int)CountRoads.Triple + 1));
        while (currentAvailables[(CountRoads)randomDependecies] == 0)
        {
            randomDependecies = Random.Range(1, ((int)CountRoads.Triple + 1));
        }

        var tmp = dictDependencies[(CountRoads)randomDependecies];
        currentAvailables[(CountRoads)randomDependecies]--;
        
        int randomIndex = Random.Range(tmp[0], tmp[^1]);

        return randomIndex;
    }
    
    public int GetTileIndex(CountRoads road)
    {
        var tmp = dictDependencies[(CountRoads)road];
        int randomIndex = Random.Range(tmp[0], tmp[^1]);

        currentAvailables[road]--;

        return randomIndex;
    }

    public void DependenciesAreFully()
    {
        foreach (var available in currentAvailables)
            if (available.Value != 0)
                return;

        OnFullyDependencies?.Invoke();
    }
}
