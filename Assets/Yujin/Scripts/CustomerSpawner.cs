using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; // �� ������
    public Transform exitPoint;  // �ⱸ ��ġ
    public string waypointTag = "Waypoint";  // ��������Ʈ �±�
    public float spawnInterval = 5.0f; // �� ���� ����

    private float timer; // Ÿ�̸�

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCustomer(); // �մ� ���� �Լ� ȣ��
            timer = 0;
        }
    }

    void SpawnCustomer()
    {
        // �մ� �ν��Ͻ� ����
        GameObject customerInstance = Instantiate(customerPrefab, transform.position, Quaternion.identity);
        CustomerAI2D customerAI = customerInstance.GetComponent<CustomerAI2D>();
        if (customerAI != null)
        {
            customerAI.waypoints = FindWaypoints(); // ��������Ʈ �Ҵ�
            customerAI.exitPoint = exitPoint;  // �ⱸ ��ġ �Ҵ�
        }
    }

    Transform[] FindWaypoints()
    {
        // ��������Ʈ ã��
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        Transform[] waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }
        return waypoints;
    }
}
