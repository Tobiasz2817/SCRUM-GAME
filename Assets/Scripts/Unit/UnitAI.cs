using System;
using System.Collections;
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
    
    public void Update() {
        MoveAI.MoveTo(navMeshAgent,pathDirection);
     
        if(Vector3.Distance(transform.position,pathDirection) < 1.5f)
        {
            DisableUnit(this);
            ReachedGoal?.Invoke();
        }
    }

    public void SetUnitDestination(Vector3 direction)
    {
        this.pathDirection = direction;
    }
    public void SetUnitImplants(CardParemeters cardParameters)
    {
        switch (cardParameters.typeImplant) {
            case TypeImplant.Health:
                SetHealthAI(cardParameters.increaser);
                break;
            case TypeImplant.Movement:
                SetSpeedAI(cardParameters.increaser);
                break;
        }
    }
    public void Damage(float damage)
    {
        var unit = GetComponent<Unit>();
        unit.unitParameters.health -= damage;
        if (unit.unitParameters.health <= 0)
        {   
            levelStats.AddMana(15);
            StartCoroutine(DestroyAfterDissolve());
        }
    }

    private IEnumerator DestroyAfterDissolve() {
        animator.StopPlayback();
        animator.enabled = false;

        navMeshAgent.SetDestination(transform.position);
        navMeshAgent.isStopped = true;
        gameObject.tag = "Untagged";

        effects.TurnDissolves(0,1f);
        while (effects.GetCurrentValue() > 0.09f) {
            yield return null;
        }
        
        Destroy(gameObject);
    }

    private void SetSpeedAI(float speed) {
        float speedDifference = (navMeshAgent.speed * speed) / 100;
        navMeshAgent.speed += speedDifference;
    }
    private void SetHealthAI(float health) {
        float healthDifference = (unitParameters.health * health) / 100;
        unitParameters.health += healthDifference;
    }
}
