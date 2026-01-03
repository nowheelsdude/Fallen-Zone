using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventario")]
    public int baseSlots = 20;
    public int slotsPerLevel = 5;

    [Header("Nivel de inventario")]
    public int inventoryLevel = 1;

    public InventorySlot[] slots;

    void Awake()
    {
        ResizeInventory();
    }

    /// <summary>
    /// Recalcula el tamaño del inventario según el nivel
    /// </summary>
    public void ResizeInventory()
    {
        int newSize = baseSlots + (inventoryLevel - 1) * slotsPerLevel;

        InventorySlot[] newSlots = new InventorySlot[newSize];

        for (int i = 0; i < newSlots.Length; i++)
        {
            if (slots != null && i < slots.Length)
                newSlots[i] = slots[i];
            else
                newSlots[i] = new InventorySlot();
        }

        slots = newSlots;

        Debug.Log("Inventario redimensionado a " + slots.Length + " slots");
    }

    public bool AddItem(ItemData item, int amount = 1)
    {
        // Stack
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].IsEmpty && slots[i].item == item)
            {
                slots[i].amount += amount;
                return true;
            }
        }

        // Slot vacío
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty)
            {
                slots[i].item = item;
                slots[i].amount = amount;
                return true;
            }
        }

        Debug.Log("Inventario lleno");
        return false;
    }
}