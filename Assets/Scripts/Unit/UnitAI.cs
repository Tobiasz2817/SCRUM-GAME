using System;
using UnityEngine;
using UnityEngine.AI;


public class UnitAI : Unit
{
    private NavMeshAgent navMeshAgent;
    private Vector3 pathDirection;

    public static event Action<Unit> ReachedGoal;

    private void Awake()
    {
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
}
