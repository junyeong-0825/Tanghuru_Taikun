using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGameController : MonoBehaviour
{
    public GameObject FruitAndStickGame;
    public GameObject TanghuruGame;
    public GameObject NextGameButton;
    public Slider slider;
    public GameObject BeforeTanghuru;
    public GameObject AfterTanghuru;
    public GameObject ClearButton;
    private int _clearNum;
    private bool InGame;

    private void Update()
    {
        
    }

    public void StartGameBtn()
    {
        _clearNum = 0;
        FruitAndStickGame.SetActive(true);
        NextGameButton.SetActive(true);

    }
    
    public void NextGameBtn()
    {
        if (_clearNum == 12)
        {
            NextGameButton.SetActive(false);
            FruitAndStickGame.SetActive(false);
            TanghuruGame.SetActive(true);
        }
        else
            _clearNum = 0;
           
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

        while(InGame)
        {
            slider.value += Time.deltaTime;
            if(slider.value > 1 )
            slider.value -=1;
                          
        }
    }

    public void PullBtn()
    {
        InGame = false;
        BeforeTanghuru.SetActive(true);
        AfterTanghuru.SetActive(false);
        if(slider.value < 0.55 &&  slider.value > 0.45)
        {
            ClearButton.SetActive(true);
        }

    }

    public void GameClearBtn()
    {
        TanghuruGame.SetActive(false);
    }

}
