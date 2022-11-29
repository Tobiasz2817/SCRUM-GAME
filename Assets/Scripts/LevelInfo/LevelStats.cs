using UnityEngine.UI;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public Text ManaUI;
    public float mana;
    public float manaGrowth;
    private void Start()
    {
        mana = 100;
        manaGrowth = 1;
        InvokeRepeating("GrowMana", 0f, 1f); 
    }
    
    private void Update()
    {
        ManaUI.text = "Mana: " + mana.ToString();
    }
    void GrowMana()
    {
        mana += manaGrowth;
    }
   
}
