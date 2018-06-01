using UnityEngine;

public class BasicTower : MonoBehaviour {

    private Transform target;

    [Header("Arrtibutes")]
    public float range = 4f;
    //[SerializeField]
    public float fireRate = 1f;
    //[SerializeField]
    public float fireCountdown = 0.5f;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public GameObject projectileSprite;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject projectileGo = (GameObject)Instantiate(projectileSprite, transform.position, transform.rotation);
        Projectile projectile = projectileGo.GetComponent<Projectile>();

        if (projectile != null) projectile.Seek(target);
        
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance < range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
