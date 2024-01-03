using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string requestedTangHuru; // ��û�� ���ķ�
    private Vector3 destination; // ������
    private float moveSpeed = 5f;


    // �մ��� �̵� �� ��û�� �ʱ�ȭ�ϴ� �޼���
    public void Initialize(Vector3 destination, string requestedTangHuru)
    {
        this.destination = destination;
        this.requestedTangHuru = requestedTangHuru;
        StartCoroutine(MoveToDestination());
    }

    // ���������� �̵��ϴ� �ڷ�ƾ
    private IEnumerator MoveToDestination()
    {
        while(Vector3.Distance(transform.position, destination) > 0.1f)
        {
            // Lerp�� ����Ͽ� �ε巯�� �̵� ����
            transform.position = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // �������� �������� ���� ó��
        ArriveAtDestination();
    }

    // �������� �������� ���� ó�� �޼���
    private void ArriveAtDestination()
    {
        Debug.Log("�����߽��ϴ�! ��û�� ���ķ�: " + requestedTangHuru);
    }
}
