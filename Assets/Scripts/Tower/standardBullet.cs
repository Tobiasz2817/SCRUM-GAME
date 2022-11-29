using UnityEngine;

public class standardBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    private float damage = 10f;
    private LevelStats levelStats;
    private void OnEnable()
    {
        levelStats = FindObjectOfType<LevelStats>();

    }
    public void Seek (Transform _target)
    {
        target = _target;
    }
    private void Update()
    {
        if (target == null)
        {
            Debug.Log("Target is null");
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame,Space.World);
    }

   void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        var unit = enemy.GetComponent<Unit>();
        unit.unitParameters.health -= damage;
        if (unit.unitParameters.health <= 0 )
        {
            Destroy(enemy.gameObject);
            levelStats.mana += 15f;
        }
    }
}
