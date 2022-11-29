using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitParameters unitParameters;
<<<<<<< HEAD

=======
>>>>>>> ec0c23bda3994ce74ff03479c6a3338acaa5e001
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