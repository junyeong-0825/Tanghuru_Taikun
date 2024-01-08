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
        public int price;    // ���ķ��� ����
    }

    public List<TanghuluType> tanghuluTypes;  // ���ķ� ���� ���
    private TanghuluType selectedTanghulu;    // ���õ� ���ķ�

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        //_playerItemDataController = _player.GetComponent<PlayerItemDataController>();
    }

    public void RequestTanghulu()
    {
        int randomIndex = Random.Range(0, tanghuluTypes.Count); // ������ �ε��� ����
        selectedTanghulu = tanghuluTypes[randomIndex]; // ���ķ� ����
        Debug.Log(selectedTanghulu.name + " ���ķ縦 �����߽��ϴ�. ����: " + selectedTanghulu.price);
    }

    public void CalculatePrice()
    {
        if (selectedTanghulu != null)
        {
            Debug.Log("����Ͻÿ�!!!!");
            Debug.Log("���� ����: " + selectedTanghulu.price); // ���� ���

            /*
            if(_playerItemDataController.Display1 > 0)
            {
                 Player.Instance.PlayerDatachange(selectedTanghulu, selectedTanghulu.price);
                _playerItemDataController.SellItem(Displays.DISPLAY1);
            }
            selectedTanghulu = null;  // ���� �ʱ�ȭ
            */
        }
    }
}