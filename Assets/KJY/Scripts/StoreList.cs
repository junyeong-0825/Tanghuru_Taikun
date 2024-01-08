using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreList : StoreManager
{
    
    public void BuyStick()
    {
        Buy(100, haveItem.haveStick);
    }
}
