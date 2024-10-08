using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public float timeToDestroy = 1f;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDie = "Die";

    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnDeath += OnDie;
        }
    }

    private void OnDie()
    {
        healthBase.OnDeath -= OnDie;
        PlayDieAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerAttack);
        }
    }

    private void PlayDieAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerDie);
        }
    }
}
