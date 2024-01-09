using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarManager: MonoBehaviour
{
    
    public int years = 1;
    public int months = 1;
    public int days = 1;


    public void NextDay()
    {
        if (days < 28)
        {
            days++;
        }
        else if (months < 4)
        {
            months++;
            days = 1;
        }
        else
        {
            years++;
            months = 1;
            days = 1;
        }
    }
}
