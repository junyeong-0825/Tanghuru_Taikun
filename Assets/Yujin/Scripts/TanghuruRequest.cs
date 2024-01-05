using UnityEngine;

public class TanghuluRequest : MonoBehaviour
{
    // ���ķ� ��û �� ���� ��� ������ ���
    // �մ��� ���ķ縦 �����ϸ�, ������ �翡 ���� ������ ����ϰ� �� ������ �α׷� ���

    public int minTanghulu = 1;
    public int maxTanghulu = 5;
    public int pricePerTanghulu = 100;
    private int requestedTanghulu = 0;  // ��û�� ���ķ� ����


    public void RequestTanghulu()
    {
        requestedTanghulu = Random.Range(minTanghulu, maxTanghulu + 1);
        // ���⿡���� ���� ����� ���� �ʰ�, ������ ���ķ� ������ ����
    }

    public void CalculatePrice(int quantity = 0)
    {
        int totalPrice = requestedTanghulu * pricePerTanghulu;
        Debug.Log("��û�� ���ķ�: " + requestedTanghulu + ", �� ����: " + totalPrice);
        // ��û ó�� �� requestedTanghulu �ʱ�ȭ
        requestedTanghulu = 0;
    }
}
