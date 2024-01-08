using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private bool[] _questCheck;
    public GameObject[] Current;
    public GameObject[] Reward;
    private int count;

    private void Start()
    {
        for(int i=0; i<_questCheck.Length; i++)
        {
            _questCheck[i] = false;
        }
    }

    private void Update()
    {
        if (_questCheck[0] == false)
            QuestCheck1();
        if (_questCheck[1] == false)
            QuestCheck2();
        if (_questCheck[2] == false)
            QuestCheck3();
        if (_questCheck[3] == false)
            QuestCheck4();

        count = Player.Instance.Sugar;
    }

    private void QuestCheck1()
    {
        if(Player.Instance.Level >= 2)
        {
            if(Player.Instance.Money > 10000)
            {
                Current[0].SetActive(false);
                Reward[0].SetActive(true);
                _questCheck[0] = true;
                Player.Instance.PlayerDataChange(1, 1000);
            }
        }

    }

    private void QuestCheck2()
    {
        if (Player.Instance.Level >= 4)
        {
            if (Player.Instance.AdBonus2 >= 5)
            {
                Current[1].SetActive(false);
                Reward[1].SetActive(true);
                _questCheck[1] = true;
                Player.Instance.PlayerDataChange(1, 10000);
            }
        }

    }

    private void QuestCheck3()
    {
        if (Player.Instance.Level >= 6)
        {
            if (Player.Instance.ChainBouns >= 8)
            {
                Current[2].SetActive(false);
                Reward[2].SetActive(true);
                _questCheck[2] = true;
                Player.Instance.PlayerDataChange(1, 100000);
            }
        }

    }

    private void QuestCheck4()
    {
        if (Player.Instance.Level >= 8)
        {
            if (count <= 1)
            {
                Current[3].SetActive(false);
                Reward[3].SetActive(true);
                _questCheck[3] = true;
                Player.Instance.PlayerDataChange(1, 1000000);
            }
        }

    }


}
