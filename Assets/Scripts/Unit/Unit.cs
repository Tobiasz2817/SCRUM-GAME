using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitParameters unitParameters;
    protected void DisableUnit(Unit unit)
    {
        Debug.Log("REACHED");
        Destroy(unit.gameObject);
    }

}

[Serializable]
public struct UnitParameters
{
    public float health;
    public int damage;
}