using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Node_Controll : MonoBehaviour
{
    private GameObject turret;
    public Color hoverColor;
    private Renderer rend;
    public Vector3 positionOffset;
    private Color startColor;
    Build_Controll build_Controll;
    private LevelStats levelStats;
    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        build_Controll = Build_Controll.instance;
    }

    private void OnEnable()
    {
        levelStats = FindObjectOfType<LevelStats>();

    }

    void OnMouseDown()
    {
        if (build_Controll.towerToBuild == null)
        {
            Debug.Log("Shop tower is not selected");
        }
        if (turret!= null)
        {
            Debug.Log("Cant build here");
            return;
        }
        GameObject turretToBuild = build_Controll.GetTurretToBuild();
        if (turretToBuild == null) return;
        if (levelStats.mana < turretToBuild.GetComponent<Tower>().cost)
        {
            Debug.Log("not enough mana");
        }
        else
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, Quaternion.identity);
            levelStats.mana -= turretToBuild.GetComponent<Tower>().cost;
        }
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
