using UnityEngine;
using System.Collections.Generic;

public class TanghuluRequest : MonoBehaviour
{
    private PlayerItemDataController _playerItemDataController;
    private GameObject _player;

    [System.Serializable]
    public class TanghuluType
    {
        public string name;  // 탕후루의 이름
        public int number;    // 탕후루 번호
    }

    public List<TanghuluType> tanghuluTypes;  // 탕후루 유형 목록
    private TanghuluType selectedTanghulu;    // 선택된 탕후루

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _playerItemDataController = _player.GetComponent<PlayerItemDataController>();
    }

    public void RequestTanghulu()
    {
        int randomIndex = Random.Range(0, tanghuluTypes.Count); // 무작위 인덱스 선택
        selectedTanghulu = tanghuluTypes[randomIndex]; // 탕후루 선택
        Debug.Log(selectedTanghulu.name + " 탕후루를 선택했습니다. 가격: " + selectedTanghulu.number * 1000);
    }

    public void CalculatePrice()
    {
        if (selectedTanghulu != null)
        {
            switch (selectedTanghulu.number)
            {
                case 1:
                    if(_playerItemDataController.Display1 > 0)
                    {
                        Player.Instance.PlayerDataChange(1, 1000);
                        _playerItemDataController.SellItem(Displays.DISPLAY1);
                    }
                    break;
                case 2:
                    if (_playerItemDataController.Display1 > 0)
                    {
                        Player.Instance.PlayerDataChange(1, 2000);
                        _playerItemDataController.SellItem(Displays.DISPLAY2);
                    }
                      
                    break;
                case 3:
                    if (_playerItemDataController.Display1 > 0)
                    {
                        Player.Instance.PlayerDataChange(1, 3000);
                        _playerItemDataController.SellItem(Displays.DISPLAY3);
                    }
                       
                    break;
                case 4:
                    if (_playerItemDataController.Display1 > 0)
                    {
                        Player.Instance.PlayerDataChange(1, 4000);
                        _playerItemDataController.SellItem(Displays.DISPLAY4);
                    }
                      
                    break;
                case 5:
                    if (_playerItemDataController.Display1 > 0)
                    {
                        Player.Instance.PlayerDataChange(1, 5000);
                        _playerItemDataController.SellItem(Displays.DISPLAY5);
                    }
               
                    break;
            }
            selectedTanghulu = null;  // 선택 초기화
        }
    }
}