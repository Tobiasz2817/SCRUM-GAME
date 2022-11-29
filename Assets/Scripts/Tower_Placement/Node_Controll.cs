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
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret!= null)
        {
            Debug.Log("Cant build there");
            return;
        }
        GameObject turretToBuild = Build_Controll.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
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
