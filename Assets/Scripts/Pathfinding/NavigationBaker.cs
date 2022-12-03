using System;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;

public class NavigationBaker : MonoBehaviour {

    private NavMeshSurface surface;

    private List<Transform> tilePath = new List<Transform>();
    
    private void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }
    void Start ()
    {
        tilePath = GetComponentsInChildren<Transform>().ToList();
    }

    private void OnEnable()
    {
        TilesController.OnTileAdded += GenerateSurface;
    }

    private void OnDisable()
    {
        TilesController.OnTileAdded -= GenerateSurface;
    }
    
    private void GenerateSurface(Transform[] tilePath_)
    {
        foreach (var path in tilePath_)
        {
            // Creating object path
            var newPath = Instantiate(path,path.position,path.rotation, transform);
            tilePath.Add(newPath);
        }

        surface.BuildNavMesh();
    }

    
}