using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class StoreManager : MonoBehaviour
{
    //소지금에 대한 정보를 받아와야함
    protected Inventory inventory;
    public PlayerItemDataController playerItemDataController;
    public TMP_Text gold;

    public GameObject shopWindow;

    public static StoreManager Instance;

    [Header("Events")]
    public UnityEvent onOpenStore;
    public UnityEvent onCloseStore;

    void Awake()
    {
        Instance = this;
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        playerItemDataController = GameObject.Find("Player").GetComponent<PlayerItemDataController>();
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
        if(Player.Instance.Money >= item.price) 
        {
            
            Player.Instance.PlayerDataChange(1, -item.price);
            //inventory.AddItem(item);
            if (item.price == 200)
            {
                playerItemDataController.GetResource(Resources.RESOURCE1, 1);
            }
            else if(item.price == 500)
            {
                playerItemDataController.GetResource(Resources.RESOURCE2, 1);
            }
            else if(item.price == 800)
            {
                playerItemDataController.GetResource(Resources.RESOURCE3, 1);

            }
        }
        
    }
    public void OnShopBtn()
    {
        Toggle();
    }

    public void Toggle()
    {
        if (shopWindow.activeInHierarchy)
        {
            shopWindow.SetActive(false);
            onCloseStore?.Invoke();
        }
        else
        {
            shopWindow.SetActive(true);
            onOpenStore?.Invoke();
        }
    }
    private void Update()
    {
        gold.text = Player.Instance.Money.ToString();
    }
}
