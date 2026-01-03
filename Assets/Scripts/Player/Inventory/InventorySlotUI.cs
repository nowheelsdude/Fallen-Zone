using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMPro.TMP_Text amountText;

    public void Set(ItemData item, int amount)
    {
        if (icon == null) return;

        icon.enabled = true;
        icon.sprite = item.icon;

        if (amountText != null)
            amountText.text = amount > 1 ? amount.ToString() : "";
    }

    public void Clear()
    {
        if (icon != null)
        {
            icon.sprite = null;
            icon.enabled = false;
        }

        if (amountText != null)
            amountText.text = "";
    }
}
