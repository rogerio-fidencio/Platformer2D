using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectilePrefab;

    public Transform shootPoint;
    public float shootRate = 2f;
    public Transform playerSideReference;

    private Coroutine _shootCoroutine;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _shootCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootRate);
        }
    }

    public void Shoot()
    {
        ProjectileBase projectile = Instantiate(projectilePrefab);
        projectile.transform.position = shootPoint.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
