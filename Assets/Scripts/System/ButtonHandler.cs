using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private PlayerItemDataController _playerItemDataController;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerItemDataController = player.GetComponent<PlayerItemDataController>();
    }

    public void GetResourceBtn(int itemNumber)
    {
        switch (itemNumber)
        {
            case 1:
                _playerItemDataController.GetResource(Resources.RESOURCE1, 100);
                break;
            case 2:
                _playerItemDataController.GetResource(Resources.RESOURCE2, 100);
                break;
            case 3:
                _playerItemDataController.GetResource(Resources.RESOURCE3, 100);
                break;
            case 4:
                _playerItemDataController.GetResource(Resources.RESOURCE4, 100);
                break;
            case 5:
                _playerItemDataController.GetResource(Resources.RESOURCE5, 100);
                break;
        }

    }


    public void GetItemBtn(int itemNumber)
    {
        switch(itemNumber)
        {
            case 1:
                _playerItemDataController.Cooking(Items.ITEM1);
                break;
            case 2:
                _playerItemDataController.Cooking(Items.ITEM2);
                break;
            case 3:
                _playerItemDataController.Cooking(Items.ITEM3);
                break;
            case 4:
                _playerItemDataController.Cooking(Items.ITEM4);
                break;
            case 5:
                _playerItemDataController.Cooking(Items.ITEM5);
                break;
        }

    }

}
