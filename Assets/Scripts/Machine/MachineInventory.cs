using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MachineSlot
{
    public ItemData item;
    public int quantity;
    public string name;
}
public class MachineInventory : MonoBehaviour
{
    public MachineItemSlotUI[] uiSlots;
    public MachineSlot[] machineSlots;

    public GameObject inventoryWindow;

    [Header("Selected Item")]
    private MachineSlot selectedItem;
    private int selectedItemIndex;
    private int curEquipIndex;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    private void Start()
    {
        inventoryWindow.SetActive(false);
        machineSlots = new MachineSlot[uiSlots.Length];

        for (int i = 0; i < machineSlots.Length; i++)
        {
            machineSlots[i] = new MachineSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
    }

    public void OnInventoryButton()
    {
        Toggle();
    }


    public void Toggle()
    {
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
            onCloseInventory?.Invoke();
        }
        else
        {
            inventoryWindow.SetActive(true);
            onOpenInventory?.Invoke();
        }
    }

    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    public void AddItem(ItemData item)
    {
        if(item.canStack)
        {
            MachineSlot slotToStackTo = GetItemStack(item);
            if(slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }
        }

        MachineSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            emptySlot.name = item.displayName;
            UpdateUI();
            return;
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i< machineSlots.Length; i++)
        {
            if (machineSlots[i].item != null)
                uiSlots[i].Set(machineSlots[i]);
            else
                uiSlots[i].Clear();
        }
    }

    MachineSlot GetItemStack(ItemData item)
    {
        for (int i = 0; i < machineSlots.Length; i++)
        {
            if (machineSlots[i].item == item && machineSlots[i].quantity < item.maxStackAmount)
                return machineSlots[i];
        }

        return null;
    }

    MachineSlot GetEmptySlot()
    {
        for (int i = 0; i < machineSlots.Length; i++)
        {
            if (machineSlots[i].item == null)
                return machineSlots[i];
        }

        return null;
    }
}
