using UnityEngine;

public class TanghuluRequest : MonoBehaviour
{
    // 탕후루 요청 및 가격 계산 로직을 담당
    // 손님이 탕후루를 선택하면, 선택한 양에 따라 가격을 계산하고 이 정보를 로그로 출력

    public int minTanghulu = 1;
    public int maxTanghulu = 5;
    public int pricePerTanghulu = 100;
    private int requestedTanghulu = 0;  // 요청된 탕후루 수량


    public void RequestTanghulu()
    {
        requestedTanghulu = Random.Range(minTanghulu, maxTanghulu + 1);
        // 여기에서는 가격 계산을 하지 않고, 오로지 탕후루 수량만 결정
    }

    public void CalculatePrice(int quantity = 0)
    {
        int totalPrice = requestedTanghulu * pricePerTanghulu;
        Debug.Log("요청된 탕후루: " + requestedTanghulu + ", 총 가격: " + totalPrice);
        // 요청 처리 후 requestedTanghulu 초기화
        requestedTanghulu = 0;
    }
}
