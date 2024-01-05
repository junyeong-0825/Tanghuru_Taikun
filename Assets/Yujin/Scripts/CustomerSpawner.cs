using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public string waypointTag = "Waypoint";  // 웨이포인트 태그
    public float spawnInterval = 5.0f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnGuest();
            timer = 0;
        }
    }

    void SpawnGuest()
    {
        GameObject customerInstance = Instantiate(customerPrefab, transform.position, Quaternion.identity);
        CustomerAI2D customerAI = customerInstance.GetComponent<CustomerAI2D>();
        if (customerAI != null)
        {
            customerAI.waypoints = FindWaypoints();
        }
    }

    Transform[] FindWaypoints()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        Transform[] waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }
        return waypoints;
    }
}
