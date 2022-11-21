using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitParapeters unitParapeters;
    protected void DisableUnit(Unit unit)
    {
        unit.gameObject.SetActive(false);
        Debug.Log("REACHED");
    }
}

[Serializable]
public struct UnitParapeters
{
    public int health;
    public int damage;
}