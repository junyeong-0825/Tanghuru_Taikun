using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public GameObject MiniGameButton;
    public GameObject FruitAndStickGame;
    public GameObject TanghuruGame;
    public GameObject NextGameButton;
    public Slider slider;
    public GameObject BeforeTanghuru;
    public GameObject AfterTanghuru;
    public GameObject ClearButton;
    public GameObject CookingBtn;
    private int _clearNum;
    private bool InGame;

    private void Update()
    {
        if(InGame == true)
        {
            slider.value++;
            if (slider.value >= 100)
                slider.value -= 100;
        }
    }

    public void StartGameBtn()
    {
        _clearNum = 0;
        FruitAndStickGame.SetActive(true);
    }
    
    public void NextGameBtn()
    {
        if (_clearNum == 12)
        {
            NextGameButton.SetActive(true);
            FruitAndStickGame.SetActive(false);
            TanghuruGame.SetActive(true);
        }
           
    }

    public void GetPointBtn()
    {
        Debug.Log(_clearNum);
        _clearNum++;
    }

    public void PushBtn()
    {
        BeforeTanghuru.SetActive(false);
        AfterTanghuru.SetActive(true);
        InGame = true;

    }

    public void PullBtn()
    {
        InGame = false;
        BeforeTanghuru.SetActive(true);
        AfterTanghuru.SetActive(false);
        if(slider.value < 55 &&  slider.value > 45)
        {
            ClearButton.SetActive(true);
        }

    }

    public void GameClearBtn()
    {
        TanghuruGame.SetActive(false);
        MiniGameButton.SetActive(false);
        CookingBtn.SetActive(true);
    }


}
