using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public Transform inventoryGrid;
    public InventorySlotUI[] slotUIs;

    public GameObject inventoryPanel;

    public bool isInventoryOpen;

    void Start()
    {
        // El SCRIPT SIEMPRE activo
        slotUIs = inventoryGrid.GetComponentsInChildren<InventorySlotUI>(true);

        inventoryPanel.SetActive(false);
        isInventoryOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);

        Cursor.lockState = isInventoryOpen
            ? CursorLockMode.None
            : CursorLockMode.Locked;

        Cursor.visible = isInventoryOpen;

        if (isInventoryOpen)
            Refresh();
    }

    public void Refresh()
    {
        if (inventory == null || slotUIs == null)
        {
            Debug.LogError("InventoryUI mal configurado");
            return;
        }

        for (int i = 0; i < slotUIs.Length; i++)
        {
            if (i < inventory.slots.Length)
            {
                var slot = inventory.slots[i];

                if (slot == null || slot.IsEmpty)
                    slotUIs[i].Clear();
                else
                    slotUIs[i].Set(slot.item, slot.amount);
            }
            else
            {
                slotUIs[i].Clear();
            }
        }
    }
}
