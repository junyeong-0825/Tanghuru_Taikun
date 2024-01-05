
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuilngData : MonoBehaviour
{
    public static BuilngData instance;

    public BuilidingsObject[] builidings;
    public Button[] builiding_Image;

    private int selectIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < builidings.Length; i++)
        {
            if (builidings[i].purchase == true)
            {
                builiding_Image[i].interactable = false;
            }
        }
    }

    public void Buy()
    {
        if (selectIndex >= 0 && selectIndex < builidings.Length)
        {
            print(selectIndex);
            builidings[selectIndex].purchase = true;
        }
    }

    public void selectedIndex(int index)
    {
        selectIndex = index;
    }
}
