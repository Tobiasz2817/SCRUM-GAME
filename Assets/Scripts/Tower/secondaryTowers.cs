using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class secondaryTowers : MonoBehaviour
{
    public GameObject panel;
    private LevelStats levelStats;
    private GameObject tower;
    private int cost = 50;
    public GameObject manaBank;
    public GameObject manaGenerator;
    private GameObject towerToBuild;
    private void Awake()
    {
        levelStats = FindObjectOfType<LevelStats>();
    }
    public void SelectManaBank()
    {
        towerToBuild = manaBank;
        Buy();
        panel.SetActive(false);
    }
    public void SelectManaGenerator()
    {
        towerToBuild = manaGenerator;
        Buy();
        panel.SetActive(false);
    }
    public void Buy()
    {
        if (tower != null)
        {
            Debug.Log("Can't build here!");
            return;
        }
        if (levelStats.mana < cost)
        {
            Debug.Log("not enough mana");
        }
        else
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position, Quaternion.identity);
            levelStats.mana -= cost;
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if (panel.active == false)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }
}
