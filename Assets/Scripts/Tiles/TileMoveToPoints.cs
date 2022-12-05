using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMoveToPoints : MonoBehaviour
{
    [SerializeField] public List<Transform> spawnPositions;
    [SerializeField] public Transform finallyPosition;

    public Transform GetClosestsSpawnPoint(Transform from)
    {
        Transform finallySpawnPoint = null;
        
        float smallestDistance = float.MaxValue;
        foreach (var pos in spawnPositions)
        {
            float distance = Vector3.Distance(from.position, pos.position);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                finallySpawnPoint = pos;
            }
        }

        return finallySpawnPoint;
    }
}
