using System;
using UnityEngine;
using UnityEngine.AI;


public class UnitAI : Unit
{
    private LevelStats levelStats;
    private NavMeshAgent navMeshAgent;
    private Vector3 pathDirection;

    public static event Action ReachedGoal;

    private void Awake()
    {
        levelStats = FindObjectOfType<LevelStats>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        MoveAI.MoveTo(navMeshAgent,pathDirection);
     
        if(Vector3.Distance(transform.position,pathDirection) < 1.5f)
        {
            DisableUnit(this);
            ReachedGoal?.Invoke();
        }
    }

    public void SetUnit(Vector3 direction)
    {
        this.pathDirection = direction;
    }
    public void Damage(float damage)
    {
        var unit = GetComponent<Unit>();
        unit.unitParameters.health -= damage;
        if (unit.unitParameters.health <= 0)
        {   
            levelStats.AddMana(15);
            Destroy(gameObject);
            
        }
    }
}
