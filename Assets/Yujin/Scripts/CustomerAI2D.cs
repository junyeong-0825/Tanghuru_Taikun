using UnityEngine;

public class CustomerAI2D : MonoBehaviour
{
    public Transform[] waypoints;  // 손님이 방문할 웨이포인트들
    public Transform exitPoint;    // 출구 위치
    public float speed = 2.0f;     // 손님의 이동 속도
    public float waitTime = 1.0f;  // 각 웨이포인트에서 대기하는 시간
    public int productSelectionPoint = 2;  // 탕후루를 선택하는 웨이포인트의 인덱스
    public int checkoutPoint;  // 계산대가 있는 웨이포인트의 인덱스

    private int currentWaypointIndex = 0;  // 현재 목표 웨이포인트의 인덱스
    private float waitTimer;               // 웨이포인트에서 대기하는 타이머
    private bool hasSelectedProduct = false;  // 상품을 선택했는지 여부
    private bool isExiting = false;           // 출구로 이동 중인지 여부
    private TanghuluRequest tanghuluRequest;  // 탕후루 요청 스크립트 참조

    void Start()
    {
        checkoutPoint = waypoints.Length - 1;
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        MoveToNextWaypoint();
        tanghuluRequest = FindObjectOfType<TanghuluRequest>();
    }

    void Update()
    {
        if (isExiting)
        {
            // 출구로 이동
            MoveTowards(exitPoint);
            if (Vector2.Distance(transform.position, exitPoint.position) < 0.1f)
            {
                // 출구에 도착하면 손님 제거
                Destroy(gameObject);
            }
        }
        else if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
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
            MoveTowards(waypoints[currentWaypointIndex]);
        }
    }

    void MoveTowards(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }

    void MoveToNextWaypoint()
    {
        waitTimer = waitTime;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void SelectProduct()
    {
        hasSelectedProduct = true;
        tanghuluRequest.RequestTanghulu();
    }

    void Checkout()
    {
        if (hasSelectedProduct)
        {
            tanghuluRequest.CalculatePrice();
            isExiting = true;
        }
    }
}
