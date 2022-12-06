using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDependenciesHandler : MonoBehaviour
{
    public static TileDependenciesHandler Instance { get; private set; }
    
    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public TileDependenciesLevelData currentDependencies { set; get; }

}
