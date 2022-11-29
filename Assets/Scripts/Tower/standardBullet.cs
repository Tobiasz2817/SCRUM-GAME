using UnityEngine;

public class standardBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    private float damage = 10f;
    public void Seek (Transform _target)
    {
        target = _target;
    }
    private void Update()
    {
        if (target == null)
        {
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
        Enemy_temp.health -= damage;
        if (Enemy_temp.health <= 0 )
        {
            Destroy(enemy.gameObject);
        }
    }
}
