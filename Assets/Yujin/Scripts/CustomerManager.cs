using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab; // 손님 프리팹
    public Transform[] spawnPoints; // 손님 생성 위치
    public float spawnInterval = 30f; // 손님 생성 간격
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

        // 스테이지에 따른 탕후루 요청 범위 설정
        string requestedTangHuru = GetRequestedTangHuru(); // 랜덤 탕후루 요청 생성
        customerObj.GetComponent<Customer>().Initialize(spawnPoint, requestedTangHuru);
    }


    private Dictionary<int, List<string>> stageToTangHuruList = new Dictionary<int, List<string>>()
    {
        { 1, new List<string> { "탕후루1", "탕후루2" } },
        { 2, new List<string> { "탕후루3", "탕후루4", "탕후루5" } },
    };
    private string GetRequestedTangHuru()
    {
        int currentStage = GetCurrentStage(); // 현재 스테이지를 가져오는 로직
        if (stageToTangHuruList.ContainsKey(currentStage))
        {
            List<string> tanghuruList = stageToTangHuruList[currentStage];
            return tanghuruList[Random.Range(0, tanghuruList.Count)];
        }
        else
        {
            return "기본 탕후루";
        }
    }
    private int GetCurrentStage()
    {
        // 여기에 현재 게임 스테이지를 반환하는 로직 구현
        // 예: return GameManager.Instance.CurrentStage;
        return 1;
    }


}
