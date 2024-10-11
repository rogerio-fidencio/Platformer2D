using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleRedCoin : ItemCollectibleBase
{
    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddRedCoin();
    }
}
