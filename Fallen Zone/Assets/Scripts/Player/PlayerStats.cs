using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Inventory")]
    public int baseInventorySize = 10;
    public int bonusInventorySlots = 0;

    public int InventoryCapacity => baseInventorySize + bonusInventorySlots;
}
