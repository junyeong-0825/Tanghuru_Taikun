using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action <int> OnLevelUpEvent;
    public static Player Instance;
    public int Level { get; private set; }
    public int Money { get; private set; }
    public int Sugar { get; private set; }
    public int Stick { get; private set; }
    public int ChainBouns { get; private set; }


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

    private void Start()
    {
        PlayerStartSetting();
    }

    private void Update()
    {
        if (Stick <= 0)
            PlayerLevelUp();
    }

    private void PlayerStartSetting()
    {
        Level = 1;
        Stick = 100;
        Sugar = 1000;
        Money = 100;
    }

    public void CallLevelUpEvent(int level)
    {
        OnLevelUpEvent?.Invoke(level);
    }

    private void PlayerLevelUp()
    {
        Level++;
        Stick += Level * 100;
        CallLevelUpEvent(Level);
    }

    public void PlayerDataChange(int type, int number)
    {
        if(type == 1)
        {
            Money += number;
        }
        else if(type == 2)
        {
            Stick -= number;
        }
        else if(type == 3)
        {
            Sugar -= number;
        }
    }

}