using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;
    private int health = 10;

    private int waypointIndex = 0;
    private Transform currentWayPoint;
    
	private void Start () {
        currentWayPoint = GetWaypoints.points[0];
	}
	
	private void Update () {
        Vector2 dir = currentWayPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, currentWayPoint.position) <= 0.1f)
        {
            waypointIndex++;
            if (waypointIndex > GetWaypoints.points.Length - 1)
            {
                PlayerStats.DamagePlayer();
                Destroy(gameObject);
            }
            else
            {
                currentWayPoint = GetWaypoints.points[waypointIndex];
            }
        }
	}

    public void DamageEnemey(int damage)
    {
        health -= damage;
        CheckHealth();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Die();
        }
    }
}
