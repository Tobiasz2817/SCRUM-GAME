using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Controll : MonoBehaviour
{
    public static Build_Controll instance;

    private void Awake()
    {
        instance = this;
    }
    public GameObject normalTurretPrefab;
    public GameObject normalTurretPrefab2;
    public GameObject towerToBuild;
    public void SelectTurretToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
    public GameObject GetTurretToBuild()
    {
        return towerToBuild;
    }
}
