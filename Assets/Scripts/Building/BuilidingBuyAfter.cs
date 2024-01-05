using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BuilidingBuyAfter : MonoBehaviour
{
    public TMP_Text[] fruitCount;

    float[] count;
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

    public void Harvest()
    {

    }
}
