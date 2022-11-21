using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAI
{
    private float speed;

    public MoveAI() : this(5)
    {
    }
    public MoveAI(float speed_)
    {
        this.speed = speed_;
    }
    public void MoveTo(NavMeshAgent navMeshAgent,Vector3 direction)
    {
        navMeshAgent.SetDestination(direction);
    }
}
