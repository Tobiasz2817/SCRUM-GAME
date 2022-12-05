using TMPro;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public TMP_Text ManaUI;
    public int mana;
    public int manaGrowth;
    public int maxMana;
    private void Start()
    {
        mana = 100;
        maxMana = 200;
        manaGrowth = 1;
        InvokeRepeating("ManaGrowth", 0f, 1f); 
    }
    
    private void Update()
    {
        ManaUI.text = mana.ToString() + "/" + maxMana.ToString();
    }
    private void ManaGrowth()
    {
        AddMana(manaGrowth);
    }
    public void AddMana(int amount)
    {
        if (mana + amount <= maxMana)
            mana += amount;
    }
}
