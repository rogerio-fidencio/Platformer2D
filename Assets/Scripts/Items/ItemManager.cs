using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;

    public TextMeshProUGUI coinText;

    public int coins = 0;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoin(int amount = 1)
    {
        coins += amount;
        coinText.text = "X " + coins.ToString();
    }
}
