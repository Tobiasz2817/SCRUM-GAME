using System;
using UnityEngine;
using UnityEngine.AI;


public class UnitAI : Unit
{
    private LevelStats levelStats;
    private NavMeshAgent navMeshAgent;
    private Vector3 pathDirection;

    public static event Action<Unit> ReachedGoal;

    private void Awake()
    {
        levelStats = GetComponent<LevelStats>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        ReachedGoal += DisableUnit;
    }

    private void OnDisable()
    {
        ReachedGoal -= DisableUnit;
    }

    public void Update()
    {
        if(Vector3.Distance(transform.position,pathDirection) < 0.5f)
            ReachedGoal?.Invoke(this);
        MoveAI.MoveTo(navMeshAgent,pathDirection);
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
            //levelStats.AddMana(15);
            Destroy(gameObject);
            
        }
    }
}
