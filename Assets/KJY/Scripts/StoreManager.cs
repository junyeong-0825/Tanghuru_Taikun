using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    //소지금에 대한 정보를 받아와야함
    protected StoreTest_HaveItems haveItem;
    void Awake()
    {
        haveItem = GetComponent<StoreTest_HaveItems>();
    }
    public void Sell(int sellingPrice, int numberOfItems)
    {
        if (numberOfItems > 0)
        {
            haveItem.haveGold += sellingPrice;
            numberOfItems -= 1;
        }
        
    }
    public void Buy(int purchasePrice, int numberOfItems)
    {
        if(haveItem.haveGold > purchasePrice) 
        {
            haveItem.haveGold -= purchasePrice;
            numberOfItems += 1;
        }
        
    }
}
