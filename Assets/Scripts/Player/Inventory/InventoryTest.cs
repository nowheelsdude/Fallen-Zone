using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public PlayerInventory inventory;
    public ItemData testItem;

    void Start()
    {
        inventory.AddItem(testItem, 5);
        inventory.AddItem(testItem, 2);
    }
}
