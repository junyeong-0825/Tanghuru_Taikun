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
        public int price;    // 탕후루의 가격
    }

    public List<TanghuluType> tanghuluTypes;  // 탕후루 유형 목록
    private TanghuluType selectedTanghulu;    // 선택된 탕후루

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        //_playerItemDataController = _player.GetComponent<PlayerItemDataController>();
    }

    public void RequestTanghulu()
    {
        int randomIndex = Random.Range(0, tanghuluTypes.Count); // 무작위 인덱스 선택
        selectedTanghulu = tanghuluTypes[randomIndex]; // 탕후루 선택
        Debug.Log(selectedTanghulu.name + " 탕후루를 선택했습니다. 가격: " + selectedTanghulu.price);
    }

    public void CalculatePrice()
    {
        if (selectedTanghulu != null)
        {
            Debug.Log("계산하시오!!!!");
            Debug.Log("계산된 가격: " + selectedTanghulu.price); // 가격 계산

            /*
            if(_playerItemDataController.Display1 > 0)
            {
                 Player.Instance.PlayerDatachange(selectedTanghulu, selectedTanghulu.price);
                _playerItemDataController.SellItem(Displays.DISPLAY1);
            }
            selectedTanghulu = null;  // 선택 초기화
            */
        }
    }
}