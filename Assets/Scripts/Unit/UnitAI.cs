using System;
using UnityEngine;
using UnityEngine.AI;


public class UnitAI : Unit
{
    private MoveAI move = new MoveAI(15);

    private NavMeshAgent navMeshAgent;
    private Vector3 pathDirection;

    public static event Action<Unit> ReachedGoal;

    [SerializeField] private Transform testPoint;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetUnit(testPoint.position);
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
        
        move.MoveTo(navMeshAgent,pathDirection);
    }

    public void SetUnit(Vector3 direction)
    {
        this.pathDirection = direction;
    }
}
