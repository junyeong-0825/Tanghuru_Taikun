using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; // 고객 프리팹
    public Transform exitPoint;  // 출구 위치
    public string waypointTag = "Waypoint";  // 웨이포인트 태그
    public float spawnInterval = 5.0f; // 고객 생성 간격

    private float timer; // 타이머

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCustomer(); // 손님 생성 함수 호출
            timer = 0;
        }
    }

    void SpawnCustomer()
    {
        // 손님 인스턴스 생성
        GameObject customerInstance = Instantiate(customerPrefab, transform.position, Quaternion.identity);
        CustomerAI2D customerAI = customerInstance.GetComponent<CustomerAI2D>();
        if (customerAI != null)
        {
            customerAI.waypoints = FindWaypoints(); // 웨이포인트 할당
            customerAI.exitPoint = exitPoint;  // 출구 위치 할당
        }
    }

    Transform[] FindWaypoints()
    {
        // 웨이포인트 찾기
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        Transform[] waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }
        return waypoints;
    }
}
