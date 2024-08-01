using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonManager : MonoBehaviour
{
    public GameObject[] buttons;

    [Header("Animation")]
    public float duration = 0.5f;
    public float delay = 0.1f;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        HideButtons();
        ShowButtons();
    }

    public void HideButtons()
    {
        foreach (var button in buttons)
        {
            button.transform.localScale = Vector3.zero;
            button.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(ease);
        }
    }
}
