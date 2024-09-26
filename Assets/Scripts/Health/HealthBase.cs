using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int baseHealth = 10;
    public bool destroyOnDeath = false;
    public int delayToDestroy = 0;

    private bool _isDead = false;
    private int _currentHealth;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentHealth = baseHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        if (destroyOnDeath )
        {
            Destroy(gameObject, delayToDestroy);
        }
    }   
}
