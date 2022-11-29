using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Build_Controll build_Controll;
    void Start()
    {
        build_Controll = Build_Controll.instance;
    }
    public void SelectStandardTower()
    {
        build_Controll.SelectTurretToBuild(build_Controll.normalTurretPrefab) ;
    }
    public void SelectStandardTower2()
    {
        build_Controll.SelectTurretToBuild(build_Controll.normalTurretPrefab2);
    }

}
