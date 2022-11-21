using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TilesController : MonoBehaviour
{
    [SerializeField]
    private List<Tile> tiles = new List<Tile>();

    public List<Tile> lastTiles = new List<Tile>();

    [SerializeField] public Transform finallyPoint;
    
    void Start()
    {
        /*for (int i = 1; i < tales.Count; i++)
        {
            Debug.Log(i);
            tales[i].TaleSetup(tales[i - 1]);

            if (i - 1 == tales.Count)
            {
                // Last For Iterations
                lastTale = tales[i];
            }
        }*/
    }
    
    void Update()
    {
        
    }

    /*private void SpawnTale(int indexTale, Vector3 pos, Quaternion rot)
    {
        lastTale = Instantiate(tales[indexTale].gameObject,pos,rot,transform).GetComponent<Tale>();
    }*/

    public void OnCreateTale()
    {
        //SpawnTale(0,lastTale.);
    }
}
