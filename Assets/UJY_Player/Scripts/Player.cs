using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum Resources
{
    RESOURCE1 = 1,
    RESOURCE2,
    RESOURCE3,
    RESOURCE4,
    RESOURCE5
}

public enum Items
{
    ITEM1 = 1,
    ITEM2,
    ITEM3,
    ITEM4,
    ITEM5
}

public class Player : MonoBehaviour
{
    public static Player Instance;
    public TextMeshProUGUI ResourceText;
    public TextMeshProUGUI PlayerResourceText;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI PlayerItemText;
    private int _resourceNum;
    private int _itemNum;

    public int Level { get; private set; }
    public int Money { get; private set; }
    public int Sugar { get; private set; }
    public int Resource1 { get; private set; }
    public int Resource2 { get; private set; }
    public int Resource3 { get; private set; }
    public int Resource4 { get; private set; }
    public int Resource5 { get; private set; }
    public int Item1 { get; private set; }
    public int Item2 { get; private set; }
    public int Item3 { get; private set; }
    public int Item4 { get; private set; }
    public int Item5 { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        _resourceNum += (int)Time.deltaTime;
        ResourceText.text = _resourceNum.ToString();
        PlayerResourceText.text = Resource1.ToString();
        ItemText.text = _itemNum.ToString();
        PlayerItemText.text = Item1.ToString();
    }

    public void GetResource(Resources resourceNumber, int resourceCount)
    {
        resourceCount += _resourceNum;
        switch (resourceNumber)
        {
            case Resources.RESOURCE1:
                Resource1 += resourceCount;
                break;
            case Resources.RESOURCE2:
                Resource2 += resourceCount;
                break;
            case Resources.RESOURCE3:
                Resource3 += resourceCount;
                break;
            case Resources.RESOURCE4:
                Resource4 += resourceCount;
                break;
            case Resources.RESOURCE5:
                Resource5 += resourceCount;
                break;

        }
    }

    public void Cooking(Resources resourceNumber, int itemCount)
    {
        itemCount += 30;
        switch (resourceNumber)
        {
            case Resources.RESOURCE1:
                Resource1 -= itemCount;
                Item1 += itemCount;
                break;
            case Resources.RESOURCE2:
                Resource1 -= itemCount;
                Item1 += itemCount;
                break;
            case Resources.RESOURCE3:
                Resource1 -= itemCount;
                Item1 += itemCount;
                break;
            case Resources.RESOURCE4:
                Resource1 -= itemCount;
                Item1 += itemCount;
                break;
            case Resources.RESOURCE5:
                Resource1 -= itemCount;
                Item1 += itemCount;
                break;

        }
    }

    public void DisplayItem(Items itemNumber,int itemCount)
    {
        switch (itemNumber)
        {
            case Items.ITEM1:
                Item1 -= itemCount;
                break;
            case Items.ITEM2:
                Item1 -= itemCount;
                break;
            case Items.ITEM3:
                Item1 -= itemCount;
                break;
            case Items.ITEM4:
                Item1 -= itemCount;
                break;
            case Items.ITEM5:
                Item1 -= itemCount;
                break;

        }
    }

}
