using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MachineItemSlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI quatityText;
    public TextMeshProUGUI nameText;
    private MachineSlot curSlot;

    public int index;
    public void Set(MachineSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        quatityText.text = slot.quantity > 1 ? slot.quantity.ToString() : string.Empty;
        nameText.text = slot.quantity >= 1 ? slot.name.ToString() : string.Empty;
    }

    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
        quatityText.text = string.Empty;
    }
}