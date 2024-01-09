using UnityEngine;
using System.Collections.Generic;

public class TanghuluRequest : MonoBehaviour
{
    private PlayerItemDataController _playerItemDataController;
    private GameObject _player;

    [System.Serializable]
    public class TanghuluType
    {
        public string name;  // ���ķ��� �̸�
        public int number;    // ���ķ� ��ȣ
    }

    public List<TanghuluType> tanghuluTypes;  // ���ķ� ���� ���
    private TanghuluType selectedTanghulu;    // ���õ� ���ķ�

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _playerItemDataController = _player.GetComponent<PlayerItemDataController>();
    }

    public void RequestTanghulu()
    {
        int randomIndex = Random.Range(0, tanghuluTypes.Count); // ������ �ε��� ����
        selectedTanghulu = tanghuluTypes[randomIndex]; // ���ķ� ����
        Debug.Log(selectedTanghulu.name + " ���ķ縦 �����߽��ϴ�. ����: " + selectedTanghulu.number * 1000);
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
            selectedTanghulu = null;  // ���� �ʱ�ȭ
        }
    }
}