using Unity.AI.Navigation;
using UnityEngine;


public class NavigationBaker : MonoBehaviour {

    public NavMeshSurface[] surfaces;
 
    // Use this for initialization
    private void Awake()
    {
        surfaces = FindObjectsOfType<NavMeshSurface>();
    }

    void Start () 
    {
        /*for (int i = 0; i < surfaces.Length; i++) 
        {
            surfaces [i].BuildNavMesh ();    
        }   */ 
    }

}