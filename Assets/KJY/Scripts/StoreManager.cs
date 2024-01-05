using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    //�����ݿ� ���� ������ �޾ƿ;���
    public int haveGold = 10000;

    void Cell(int cellPrice, int numberOfItems)
    {
        if (numberOfItems > 0)
        {
            haveGold += cellPrice;
            numberOfItems -= 1;
        }
        
    }
    void Buy(int buyPrice, int numberOfItems)
    {
        if(haveGold > buyPrice) 
        {
            haveGold -= buyPrice;
            numberOfItems += 1;
        }
        
    }
}
