using System.Linq;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRendererGroup;
    public Color flashColor = Color.red;
    public float duration = 0.1f;

    private void OnValidate()
    {
        spriteRendererGroup = new List<SpriteRenderer>();
        foreach (var spriteRederer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRendererGroup.Add(spriteRederer);
        }
    }

    public void Flash()
    {
        foreach (var spriteRenderer in spriteRendererGroup)
        {
            spriteRenderer.DOBlendableColor(flashColor, duration).OnComplete(() =>
            {
                spriteRenderer.DOBlendableColor(Color.white, duration);
            });
        }
    }
}
