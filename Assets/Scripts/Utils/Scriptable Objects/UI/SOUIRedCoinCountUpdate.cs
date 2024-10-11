using TMPro;
using UnityEngine;

public class SOUIRedCoinCountUpdate : MonoBehaviour
{
    public ItemManager itemManager;

    public SOInt SOInt;

    public TextMeshProUGUI redCoinCountIntText;

    private void Awake()
    {
        itemManager.redCoinCountChange += UpdateUI;
    }

    private void UpdateUI()
    {
        redCoinCountIntText.text = "X " + itemManager.redCoinCount.value.ToString();
    }
}
