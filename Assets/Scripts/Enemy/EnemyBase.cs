using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthBase health = collision.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
