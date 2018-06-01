using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Transform target;
    public float speed = 8f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public int damage = 0;

    private void HitTarget()
    {
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 0.5f);

        if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
        EnemyMove e = enemy.GetComponent<EnemyMove>();

        if (e != null) e.DamageEnemey(damage);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	void Update () {
        if (target)
        {
            Vector2 dir = (target.position - transform.position);
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            //transform.LookAt(target);
        } else
        {
            Destroy(gameObject);
            return;
        }
	}
}
