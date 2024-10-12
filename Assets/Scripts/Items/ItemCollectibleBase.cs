using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleBase : MonoBehaviour
{

    public string tagToCompare = "Player";

    public ParticleSystem colectEffect;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToCompare))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollected();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollected()
    {
        if (colectEffect != null) colectEffect.Play();
    }
}
