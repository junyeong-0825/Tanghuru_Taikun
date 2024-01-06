using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    PlayerItemDataController _playerItemDataController;

    private void Awake()
    {
        _playerItemDataController = GetComponent<PlayerItemDataController>();
    }
    public void GetItemBtn(int itemNumber)
    {
        switch(itemNumber)
        {
            case 1:
                _playerItemDataController.Cooking(Items.ITEM1);
                break;
            case 2:
                _playerItemDataController.Cooking(Items.ITEM1);
                break;
            case 3:
                _playerItemDataController.Cooking(Items.ITEM1);
                break;
            case 4:
                _playerItemDataController.Cooking(Items.ITEM1);
                break;
            case 5:
                _playerItemDataController.Cooking(Items.ITEM1);
                break;
        }

    }

}
