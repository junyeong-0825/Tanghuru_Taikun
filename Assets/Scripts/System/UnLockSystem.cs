using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceFruitSystem : MonoBehaviour
{
    public GameObject[] FruitLocks;
    public GameObject[] QuestLocks;
    public GameObject[] FruitBtns;
    public GameObject[] Quests;
    private void Start()
    {
        Player.Instance.OnLevelUpEvent += SystemUnlock;
    }
    private void SystemUnlock(int level)
    {
        switch (level)
        {
            case 2:
                FruitLocks[0].SetActive(false);
                FruitBtns[0].SetActive(true);
                QuestLocks[0].SetActive(false);
                Quests[0].SetActive(true);
                break;
            case 3:
                FruitLocks[1].SetActive(false);
                FruitBtns[1].SetActive(true);
                break;
            case 4:
                FruitLocks[2].SetActive(false);
                FruitBtns[2].SetActive(true);
                QuestLocks[1].SetActive(false);
                Quests[1].SetActive(true);
                break;
            case 5:
                FruitLocks[3].SetActive(false);
                FruitBtns[3].SetActive(true);
                break;
            case 6:
                FruitLocks[4].SetActive(false);
                FruitBtns[4].SetActive(true);
                QuestLocks[2].SetActive(false);
                Quests[2].SetActive(true);
                break;
            case 7:
                FruitLocks[5].SetActive(false);
                FruitBtns[5].SetActive(true);
                break;
            case 8:
                FruitLocks[6].SetActive(false);
                FruitBtns[6].SetActive(true);
                QuestLocks[3].SetActive(false);
                Quests[3].SetActive(true);
                break;


        }
    }
}
