using UnityEngine;

public class machine_tower : Tower
{
    private LineRenderer trail;

    private Transform target;
   
    public Transform rotatingPart;
    public float rotationSpeed = 10f;
    public string enemyTag = "Enemy";
    public Transform firePoint;
    public GameObject panel;
    // Start is called before the first frame update
    private void Awake()
    {
        trail = GetComponent<LineRenderer>();
    }
    void Start()
    {
        trail.enabled = true;
        trail.SetPosition(0, firePoint.position);
        range = 50f;
        damage = 25f;
        fireRate = 5f;
        cost = 100;
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
        trail.SetPosition(0, firePoint.position);
        if (target == null)
        {
            if(trail.enabled == true)
            {
                trail.enabled = false;
            }
            return;
        }
        //rotation of head of tower for current model
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f); //Rotating only on y axis of the tower
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        if (!trail.enabled)
        {
            trail.enabled = true;
        }
        trail.SetPosition(1,target.position);

        target.GetComponent<UnitAI>().Damage(damage);
    }
    void OnDrawGizmosSelected() //Drawing range of tower for debug 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void OnMouseDown()
    {
        PanelActive();
    }
    public void PanelActive()
    {
        if (panel.active == false)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }
    //Trail Renderer TODO instead of bullet
}
