using System;
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
    }

    private void OnEnable()
    {
        WaveController.OnWaveEnd += CancelManaGrowth;
        TileCreatingInterface.OnNewTileCreating += InvokeManaGrowth;
    }
    private void OnDisable()
    {
        WaveController.OnWaveEnd -= CancelManaGrowth;
        TileCreatingInterface.OnNewTileCreating -= InvokeManaGrowth;
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
    
    private void InvokeManaGrowth(Tile arg1, Transform arg2)
    {
        InvokeRepeating(nameof(ManaGrowth), 0f, 1f); 
    }

    private void CancelManaGrowth(WaveDependencies obj)
    {
        CancelInvoke(nameof(ManaGrowth));
    }
}
