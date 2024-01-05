using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNumber : MonoBehaviour
{
    private int itemNumber = 0;

    public void SetItemNumber(int number)
    {
        itemNumber = number;
        Debug.Log("번호할당 : " +  itemNumber);
    }

    public int GetItemNumber()
    {
        return itemNumber;
    }
}
