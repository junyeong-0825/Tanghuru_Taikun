using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGameController : MonoBehaviour
{
    public GameObject FruitAndStickGame;
    public GameObject TanghuruGame;
    public GameObject NextGameButton;
    private int _clearNum;


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

}
