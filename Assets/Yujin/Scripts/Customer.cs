using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string requestedTangHuru; // 요청된 탕후루
    private Vector3 destination; // 목적지
    private float moveSpeed = 5f;


    // 손님의 이동 및 요청을 초기화하는 메서드
    public void Initialize(Vector3 destination, string requestedTangHuru)
    {
        this.destination = destination;
        this.requestedTangHuru = requestedTangHuru;
        StartCoroutine(MoveToDestination());
    }

    // 목적지까지 이동하는 코루틴
    private IEnumerator MoveToDestination()
    {
        while(Vector3.Distance(transform.position, destination) > 0.1f)
        {
            // Lerp를 사용하여 부드러운 이동 구현
            transform.position = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // 목적지에 도착했을 때의 처리
        ArriveAtDestination();
    }

    // 목적지에 도착했을 때의 처리 메서드
    private void ArriveAtDestination()
    {
        Debug.Log("도착했습니다! 요청된 탕후루: " + requestedTangHuru);
    }
}
