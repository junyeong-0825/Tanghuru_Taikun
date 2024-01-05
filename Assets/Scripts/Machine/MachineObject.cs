using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObject : MonoBehaviour, IInteractable
{
    public MachineData machineData;
    public GameObject machine;
    private MachineInventory machineInventory;

    private void Awake()
    {
        machineInventory = machine.GetComponent<MachineInventory>();
    }

    public void OnInteract()
    {
        machineInventory.OnInventoryButton();
    }
}
