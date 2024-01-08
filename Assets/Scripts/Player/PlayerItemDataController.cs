using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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

public enum Displays
{
    DISPLAY1 = 1,
    DISPLAY2,
    DISPLAY3,
    DISPLAY4,
    DISPLAY5
}

public class PlayerItemDataController : MonoBehaviour
{

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
    public int Display1 { get; private set; }
    public int Display2 { get; private set; }
    public int Display3 { get; private set; }
    public int Display4 { get; private set; }
    public int Display5 { get; private set; }




    public void GetResource(Resources resourceNumber, int resourceCount)
    {
        int bonusCount = Player.Instance.AdBonus1;
        switch (resourceNumber)
        {
            case Resources.RESOURCE1:
                Resource1 += resourceCount + bonusCount;
                Debug.Log(Resource1);
                break;
            case Resources.RESOURCE2:
                Resource2 += resourceCount + bonusCount;
                break;
            case Resources.RESOURCE3:
                Resource3 += resourceCount + bonusCount;
                break;
            case Resources.RESOURCE4:
                Resource4 += resourceCount + bonusCount;
                break;
            case Resources.RESOURCE5:
                Resource5 += resourceCount + bonusCount;
                break;

        }

    }


    public void Cooking(Items itemNumber)
    {
        int bonusCount = Player.Instance.AdBonus2;
        switch (itemNumber)
        {
            case Items.ITEM1:
                Item1 += Resource1 + bonusCount; 
                Player.Instance.PlayerDataChange(2, Resource1);
                Player.Instance.PlayerDataChange(3, Resource1);
                Resource1 = 0;
                break;
            case Items.ITEM2:
                Item2 += Resource2 + bonusCount;
                Player.Instance.PlayerDataChange(2, Resource2);
                Player.Instance.PlayerDataChange(3, Resource2);
                Resource2 = 0;
                break;
            case Items.ITEM3:
                Item3 += Resource3 + bonusCount;
                Player.Instance.PlayerDataChange(2, Resource3);
                Player.Instance.PlayerDataChange(3, Resource3);
                Resource3 = 0;
                break;
            case Items.ITEM4:
                Item4 += Resource4 + bonusCount;
                Player.Instance.PlayerDataChange(2, Resource4);
                Player.Instance.PlayerDataChange(3, Resource4);
                Resource4 = 0;
                break;
            case Items.ITEM5:
                Item5 += Resource5 + bonusCount;
                Player.Instance.PlayerDataChange(2, Resource5);
                Player.Instance.PlayerDataChange(3, Resource5);
                Resource5 = 0;
                break;

        }
        Debug.Log(Item1);
    }

    public void DisplayItem(Displays displayNumber)
    {
        switch (displayNumber)
        {
            case Displays.DISPLAY1:
                Display1 += Item1;
                Item1 = 0;
                break;
            case Displays.DISPLAY2:
                Display2 += Item2;
                Item1 = 0;
                break;
            case Displays.DISPLAY3:
                Display3 += Item3;
                Item1 = 0;
                break;
            case Displays.DISPLAY4:
                Display4 += Item4;
                Item1 = 0;
                break;
            case Displays.DISPLAY5:
                Display5 += Item5;
                Item1 = 0;
                break;

        }
    }

    public void SellItem(Displays displayNumber)
    {
        switch (displayNumber)
        {
            case Displays.DISPLAY1:
                Display1--;
                break;
            case Displays.DISPLAY2:
                Display2--;
                break;
            case Displays.DISPLAY3:
                Display3--;
                break;
            case Displays.DISPLAY4:
                Display4--;
                break;
            case Displays.DISPLAY5:
                Display5--;
                break;

        }
    }
}
