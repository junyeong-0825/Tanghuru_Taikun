using UnityEngine;

public class CustomerAI2D : MonoBehaviour
{
    public GameObject popUI;  // 팝업 UI

    public Transform[] waypoints;  // 방문할 웨이포인트
    public Transform exitPoint;    // 출구 위치
    public float speed = 2.0f;     // 이동 속도
    public int productSelectionPoint = 2;  // 탕후루 선택 웨이포인트 인덱스
    public int checkoutPoint = 8;  // 계산대 웨이포인트 인덱스

    private int currentWaypointIndex = 0;  // 현재 목표 웨이포인트 인덱스
    private float waitTimer;               // 웨이포인트에서 대기 타이머
    private bool hasSelectedProduct = false;  // 제품 선택 여부
    private bool isExiting = false;           // 출구로 이동 중인지 여부
    private TanghuluRequest tanghuluRequest;  // 탕후루 요청 스크립트 참조

    void Start()
    {
        popUI.gameObject.SetActive(false);
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        GameObject _exitPoint = GameObject.FindGameObjectWithTag("ExitPoint");

        waypoints = new Transform[waypointObjects.Length];
        exitPoint = _exitPoint.transform;
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        // 첫 번째 방문할 웨이포인트를 무작위 선택
        currentWaypointIndex = Random.Range(0, 8);
        waitTimer = Random.Range(1f, 2f);  // 1-2초 대기 시간 설정

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
                Destroy(gameObject);  // 출구 도착 시 손님 제거
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                if (waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                }
                else
                {
                    if (!hasSelectedProduct)
                    {
                        SelectProduct();
                        currentWaypointIndex = checkoutPoint;  // 계산대로 이동
                    }
                    else if (currentWaypointIndex == checkoutPoint)
                    {
                        Checkout();
                    }

                    // 다음 웨이포인트로 이동 설정
                    waitTimer = Random.Range(1f, 2f);  // 1-2초 대기 시간 설정
                }
            }
            else
            {
                MoveTowards(waypoints[currentWaypointIndex]);
            }
        }
    }

    void MoveTowards(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }

    void SelectProduct()
    {
        hasSelectedProduct = true;
        tanghuluRequest.RequestTanghulu();
        popUI.gameObject.SetActive(true);
    }

    void Checkout()
    {
        if (hasSelectedProduct)
        {
            tanghuluRequest.CalculatePrice();
            isExiting = true;
            popUI.gameObject.SetActive(false);
        }
    }
}
