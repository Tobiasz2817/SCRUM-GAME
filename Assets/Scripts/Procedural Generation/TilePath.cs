using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class TilePath : MonoBehaviour
{
    [SerializeField] private Transform[] tileSurfacePathAr;

    public Transform[] TileSurfacePath()
    {
        return tileSurfacePathAr;
    }
}
