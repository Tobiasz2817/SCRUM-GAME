using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    public float fireRate;
    public float fireCountdown;
    public float damage;
    public int cost;
    public int upgrade_level;
    private LevelStats levelStats;
    public GameObject panel;
    private Transform camera;

    private void Awake()
    {
        levelStats = FindObjectOfType<LevelStats>();
        camera = Camera.main.transform;
    }
    public void Upgrade()
    {
        if (levelStats.mana >= (cost / 2))
        {
            levelStats.mana -= (cost / 2);
            this.range += 10;
            this.damage += 5;
            this.fireRate += 1;
        }
        else
            Debug.Log("Not enough currency");
    }
    private void Update()
    {
        Vector3 vec = camera.transform.eulerAngles;
        vec.x = 0;
        if (panel.active == true)
        {
            panel.transform.rotation = Quaternion.Euler(vec);
        }    
    }
    public void PanelActive()
    {
        if (panel.active == false)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }
}
