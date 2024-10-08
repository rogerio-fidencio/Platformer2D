using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector2 direction;

    public float lifeTime = 2f;

    public float side;

    public int damage = 5;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthBase>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
