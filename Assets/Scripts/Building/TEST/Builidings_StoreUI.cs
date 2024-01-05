using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builidings_StoreUI : MonoBehaviour
{
    public GameObject slot;
    public Transform slotSpawn;

    private void Start()
    {
        SlotCreate();
    }

    private void SlotCreate()
    {
        int count = 0;

        for(int y = 0; y < 2; y++)
        {
            for(int x = 0;  x < 4; x++)
            {
                GameObject newSlot = Instantiate(slot, slotSpawn);

                Vector2 slotPosition = new Vector2(x * 300, y * -300);
                newSlot.transform.localPosition = slotPosition;

                ItemNumber itemnumber = newSlot.GetComponent<ItemNumber>();
                if(itemnumber != null)
                {
                    itemnumber.SetItemNumber(count);
                }
                count++;
            }
        }
    }
}
