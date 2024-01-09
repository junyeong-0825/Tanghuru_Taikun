using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private PlayerItemDataController _playerItemDataController;
    private GameObject _player;
    private BuildingBuyAfter _buildingBuyAfter;
    private int _money;
    private int _chain;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerItemDataController = _player.GetComponent<PlayerItemDataController>();
        _buildingBuyAfter = GameManager.Instance.gameObject.GetComponent<BuildingBuyAfter>();
    }

    public void GetResourceBtn(int itemNumber)
    {
        int resourceCount = _buildingBuyAfter.Harvest(itemNumber);
        switch (itemNumber+1)
        {
            case 1:
                _playerItemDataController.GetResource(Resources.RESOURCE1, resourceCount);
                break;
            case 2:
                _playerItemDataController.GetResource(Resources.RESOURCE2, resourceCount);
                break;
            case 3:
                _playerItemDataController.GetResource(Resources.RESOURCE3, resourceCount);
                break;
            case 4:
                _playerItemDataController.GetResource(Resources.RESOURCE4, resourceCount);
                break;
            case 5:
                _playerItemDataController.GetResource(Resources.RESOURCE5, resourceCount);
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

    public void ChainUpgradeBtn()
    {
        _money = Player.Instance.Money;
        _chain = Player.Instance.ChainBouns;
        int num = Random.Range(0, 10);
        int charge = _chain * 1000;
        if(_money >= charge)
        {
            Player.Instance.PlayerDataChange(0, charge);
            if (num > _chain)
            {
                Player.Instance.ChangeChainBonus();
            }
        }
    }

    public void GetAdBtn1()
    {
        _money = Player.Instance.Money;
        if (_money >= 10000)
        {
            int num = Random.Range(0, 10);
            Player.Instance.PlayerDataChange(0, 10000);
            Player.Instance.ChangeAdBonus1(num);

        }

    }

    public void GetAdBtn2()
    {
        _money = Player.Instance.Money;
        if (_money >= 10000)
        {
            int num = Random.Range(0, 10);
            Player.Instance.PlayerDataChange(0, 10000);
            Player.Instance.ChangeAdBonus2(num);
        }

    }

}
