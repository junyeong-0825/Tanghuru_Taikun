using UnityEngine;
using System.Collections.Generic;

public class TanghuluRequest : MonoBehaviour
{
    [System.Serializable]
    public class TanghuluType
    {
        public string name;  // ���ķ��� �̸�
        public int price;    // ���ķ��� ����
    }

    public List<TanghuluType> tanghuluTypes;  // ���ķ� ���� ���
    private TanghuluType selectedTanghulu;    // ���õ� ���ķ�

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
            // �ʿ��� �߰� ����.. ���� �Ŵ������� ���� +-�ϸ� �ɵ�?
            selectedTanghulu = null;  // ���� �ʱ�ȭ
        }
    }
}