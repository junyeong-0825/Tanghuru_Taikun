using UnityEngine;
using System.Collections.Generic;

public class TanghuluRequest : MonoBehaviour
{
    [System.Serializable]
    public class TanghuluType
    {
        public string name;  // 탕후루의 이름
        public int price;    // 탕후루의 가격
    }

    public List<TanghuluType> tanghuluTypes;  // 탕후루 유형 목록
    private TanghuluType selectedTanghulu;    // 선택된 탕후루

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
            // 필요한 추가 로직.. 게임 매니저에서 가격 +-하면 될듯?
            selectedTanghulu = null;  // 선택 초기화
        }
    }
}