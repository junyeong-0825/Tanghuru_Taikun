using UnityEngine;

public class CustomerAI2D : MonoBehaviour
{
    public Transform[] waypoints;  // �մ��� �湮�� ��������Ʈ��
    public Transform exitPoint;    // �ⱸ ��ġ
    public float speed = 2.0f;     // �մ��� �̵� �ӵ�
    public float waitTime = 1.0f;  // �� ��������Ʈ���� ����ϴ� �ð�
    public int productSelectionPoint = 2;  // ���ķ縦 �����ϴ� ��������Ʈ�� �ε���
    public int checkoutPoint;  // ���밡 �ִ� ��������Ʈ�� �ε���

    private int currentWaypointIndex = 0;  // ���� ��ǥ ��������Ʈ�� �ε���
    private float waitTimer;               // ��������Ʈ���� ����ϴ� Ÿ�̸�
    private bool hasSelectedProduct = false;  // ��ǰ�� �����ߴ��� ����
    private bool isExiting = false;           // �ⱸ�� �̵� ������ ����
    private TanghuluRequest tanghuluRequest;  // ���ķ� ��û ��ũ��Ʈ ����

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
            // �ⱸ�� �̵�
            MoveTowards(exitPoint);
            if (Vector2.Distance(transform.position, exitPoint.position) < 0.1f)
            {
                // �ⱸ�� �����ϸ� �մ� ����
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
            // ��������Ʈ�� �̵�
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
