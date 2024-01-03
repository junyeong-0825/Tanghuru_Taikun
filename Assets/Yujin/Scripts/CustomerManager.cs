using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab; // �մ� ������
    public Transform[] spawnPoints; // �մ� ���� ��ġ
    public float spawnInterval = 30f; // �մ� ���� ����
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnCustomer();
            timer = 0f;
        }
    }

    private void SpawnCustomer()
    {
        Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        GameObject customerObj = Instantiate(customerPrefab, spawnPoint, Quaternion.identity);

        // ���������� ���� ���ķ� ��û ���� ����
        string requestedTangHuru = GetRequestedTangHuru(); // ���� ���ķ� ��û ����
        customerObj.GetComponent<Customer>().Initialize(spawnPoint, requestedTangHuru);
    }


    private Dictionary<int, List<string>> stageToTangHuruList = new Dictionary<int, List<string>>()
    {
        { 1, new List<string> { "���ķ�1", "���ķ�2" } },
        { 2, new List<string> { "���ķ�3", "���ķ�4", "���ķ�5" } },
    };
    private string GetRequestedTangHuru()
    {
        int currentStage = GetCurrentStage(); // ���� ���������� �������� ����
        if (stageToTangHuruList.ContainsKey(currentStage))
        {
            List<string> tanghuruList = stageToTangHuruList[currentStage];
            return tanghuruList[Random.Range(0, tanghuruList.Count)];
        }
        else
        {
            return "�⺻ ���ķ�";
        }
    }
    private int GetCurrentStage()
    {
        // ���⿡ ���� ���� ���������� ��ȯ�ϴ� ���� ����
        // ��: return GameManager.Instance.CurrentStage;
        return 1;
    }


}
