using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class First_Tower : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public Transform rotatingPart;
    public float rotationSpeed = 10f;
    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        //close to tower targeting TODO implement more :)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceToEnemy;
                closestEnemy = enemy;
            }
        }


        if (closestEnemy != null && shortestDistanceToEnemy <= range)
        {
            target = closestEnemy.transform;
        }
        else
            target = null;

    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //rotation of head of tower for current model
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(0f, rotation.y , 0f); //Rotating only on y axis of the tower
    }
    void OnDrawGizmosSelected() //Drawing range of tower for debug 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
