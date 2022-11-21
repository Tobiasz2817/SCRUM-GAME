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

    public GameObject NormalTurretPrefab;
    private GameObject turretToBuild;
    private void Start()
    {
        turretToBuild = NormalTurretPrefab;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
