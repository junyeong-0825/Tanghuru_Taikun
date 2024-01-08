using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class StoreManager : MonoBehaviour
{
    //소지금에 대한 정보를 받아와야함
    protected Inventory inventory;
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
        if(inventory.gold >= item.price) 
        {
            inventory.gold -= item.price;
            inventory.AddItem(item);
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
        gold.text = inventory.gold.ToString();
    }
}
