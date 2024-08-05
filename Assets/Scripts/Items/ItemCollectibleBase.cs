using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleBase : MonoBehaviour
{

    public string tagToCompare = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Collected");
        OnCollected();
        Destroy(gameObject);
    }

    protected virtual void OnCollected()
    {

    }
}
