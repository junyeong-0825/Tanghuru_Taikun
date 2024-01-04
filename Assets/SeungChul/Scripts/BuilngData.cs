
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuilngData : MonoBehaviour
{
    public static BuilngData instance;

    public BuilidingsObject[] builidings;
    public SpriteRenderer[] builiding_sprites;
    public GameObject[] builiding_images;

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

    private void Start()
    {
        for (int i = 0; i < builidings.Length; i++)
        {
            if (builidings[i].purchase == true)
            {
                builiding_sprites[i].sprite = builidings[i].sprite;
                builiding_images[i].SetActive(true);
            }
        }
    }

    public void Buy()
    {
        if (selectIndex >= 0 && selectIndex < builidings.Length)
        {
            print(selectIndex);
            builiding_sprites[selectIndex].sprite = builidings[selectIndex].sprite;
            builiding_images[selectIndex].SetActive(true);
            builidings[selectIndex].purchase = true;
        }
    }

    public void selectedIndex(int index)
    {
        selectIndex = index;
    }
}
