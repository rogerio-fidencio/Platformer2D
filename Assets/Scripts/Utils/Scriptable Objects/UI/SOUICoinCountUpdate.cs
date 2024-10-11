using TMPro;
using UnityEngine;

public class SOUICoinCountUpdate : MonoBehaviour
{

    public ItemManager itemManager;

    public SOInt SOInt;

    public TextMeshProUGUI coinCountIntText;

    private void Awake()
    {
        itemManager.coinCountChange += UpdateUI;
    }

    private void UpdateUI()
    {
        coinCountIntText.text = "X " + itemManager.coinCount.value.ToString();
    }
}
