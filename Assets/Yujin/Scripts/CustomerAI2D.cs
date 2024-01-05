using UnityEngine;

public class CustomerAI2D : MonoBehaviour
{
    public Transform[] waypoints;  // 고객이 방문할 웨이포인트들
    public float speed = 2.0f;  // 고객의 이동 속도
    public float waitTime = 1.0f;  // 각 웨이포인트에서 대기하는 시간
    public int productSelectionPoint = 2;  // 탕후루를 선택하는 웨이포인트의 인덱스
    public int checkoutPoint = 4;  // 계산대가 있는 웨이포인트의 인덱스

    private int currentWaypointIndex = 0;  // 현재 목표 웨이포인트의 인덱스
    private float waitTimer;  // 웨이포인트에서 대기하는 타이머
    private bool hasSelectedProduct = false;  // 상품을 선택했는지 여부
    private TanghuluRequest tanghuluRequest;  // 탕후루 요청 스크립트 참조

    private bool isProductSelected = false;  // 탕후루를 선택했는지 여부
    private bool isCheckoutReady = false;    // 계산 준비가 되었는지 여부

    void Start()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        MoveToNextWaypoint();
        tanghuluRequest = FindObjectOfType<TanghuluRequest>();  // 탕후루 요청 스크립트 찾기
    }

    void Update()
    {
        // 웨이포인트에 도착했는지 검사
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // 웨이포인트에서 대기
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                // 탕후루 선택 또는 계산대에서 결제
                if (currentWaypointIndex == productSelectionPoint && !hasSelectedProduct)
                {
                    SelectProduct();
                }
                else if (currentWaypointIndex == checkoutPoint)
                {
                    Checkout();
                }
                MoveToNextWaypoint();
            }
        }
        else
        {
            // 웨이포인트로 이동
            MoveTowardsWaypoint();
        }

        // 탕후루 선택 로직
        if (currentWaypointIndex == productSelectionPoint && !isProductSelected)
        {
            SelectProduct();
            ShowThoughtBubble();  // 말풍선 표시 함수 호출
        }

        // 계산대에서 결제 로직
        if (currentWaypointIndex == checkoutPoint && isCheckoutReady)
        {
            Checkout();
        }

    }

    void MoveTowardsWaypoint()
    {
        // 현재 웨이포인트로 이동
        Vector2 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }

    void MoveToNextWaypoint()
    {
        // 다음 웨이포인트로 이동 설정
        waitTimer = waitTime;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void SelectProduct()
    {
        isProductSelected = true;
        tanghuluRequest.RequestTanghulu();
        isCheckoutReady = true;  // 계산 준비 상태로 설정
    }

    void ShowThoughtBubble()
    {
        // 말풍선 표시 로직
        // 예: 말풍선 오브젝트 활성화 또는 UI 요소 표시
    }
    void Checkout()
    {
        if (hasSelectedProduct)
        {
            tanghuluRequest.CalculatePrice();
            isCheckoutReady = false;  // 결제 후 계산 준비 상태 해제
            isProductSelected = false; // 상품 선택 상태 해제
        }
    }
}
