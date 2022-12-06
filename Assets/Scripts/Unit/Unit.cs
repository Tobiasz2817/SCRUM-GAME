using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitParameters unitParameters;
    protected void DisableUnit(Unit unit)
    {
        Destroy(unit.gameObject);
        Debug.Log("REACHED");
    }

}

[Serializable]
public struct UnitParameters
{
    public float health;
    public int damage;
}