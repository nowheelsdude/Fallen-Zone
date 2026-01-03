using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Consumable",
    menuName = "Items/Consumable"
)]
public class ConsumableItemData : ItemData
{
    [Header("Consumable Effects")]
    public float healthRestore;
    public float hungerRestore;
    public float thirstRestore;
}
