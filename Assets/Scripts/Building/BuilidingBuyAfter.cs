using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingBuyAfter : MonoBehaviour
{
    public TMP_Text[] fruitCount;

    private float[] count;

    private void Start()
    {
        count = new float[fruitCount.Length];
    }
    // Update is called once per frame
    void Update()
    {
        int length = BuilngData.instance.builidings.Length;

        for (int i = 0; i < length; i++)
        {
            if (BuilngData.instance.builidings[i].purchase == true)
            {
                count[i] += Time.deltaTime;
                fruitCount[i].text = count[i].ToString("N0");
            }
        }
    }

    public int Harvest(int itemNumber)
    {
        int returnValue = 0;
        returnValue = (int)count[itemNumber];
        count[itemNumber] = 0;
        return returnValue;
    }
}
