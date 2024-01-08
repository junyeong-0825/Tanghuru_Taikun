using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    //소지금에 대한 정보를 받아와야함
    protected Inventory inventory;

    void Awake()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        Debug.Log("1");
    }
    //public void Sell(ItemData item)
    //{
    //    if (numberOfItems > 0)
    //    {
    //        inventory.gold += item.price;
    //        numberOfItems -= 1;
    //    }
    //}
    public void Buy(ItemData item)
    {
        if(inventory.gold > item.price) 
        {
            inventory.gold -= item.price;
            inventory.AddItem(item);
        }
        
    }
}
