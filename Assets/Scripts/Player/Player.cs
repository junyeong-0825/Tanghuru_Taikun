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
    private int _resourceNum;
    private int _itemNum;
    private float time;

    //플레이어 정보, 재료리스트, 아이템 리스트
    #region
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
    #endregion

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
        time+= Time.deltaTime;
        if(time > 1)
        {
            _resourceNum += 100;
            time = 0;
        }
    }

    //플레이어의 재료얻기, 탕후루 만들기, 진열하기 등의 기능을 하는 함수들
    #region
    public void GetResource(Resources resourceNumber)
    {
        int resourceCount = 30;
        switch (resourceNumber)
        {
            case Resources.RESOURCE1:
                Resource1 += _resourceNum;
                _resourceNum = 0;
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

    public void Cooking(Resources resourceNumber)
    {
        int itemCount = 30;
        switch (resourceNumber)
        {
            case Resources.RESOURCE1:
                if (Resource1 >= 30)
                {
                    Resource1 -= itemCount;
                    Item1 += itemCount;
                }
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

    public void DisplayItem(Items itemNumber)
    {
        int itemCount = 30;
        switch (itemNumber)
        {
            case Items.ITEM1:
                if(Item1 >= 30)
                {
                    Item1 -= itemCount;
                    _itemNum += 30;
                }
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
    #endregion
}
