using UnityEngine;

public class CustomerAI2D : MonoBehaviour
{
    public Transform[] waypoints;  // ���� �湮�� ��������Ʈ��
    public float speed = 2.0f;  // ���� �̵� �ӵ�
    public float waitTime = 1.0f;  // �� ��������Ʈ���� ����ϴ� �ð�
    public int productSelectionPoint = 2;  // ���ķ縦 �����ϴ� ��������Ʈ�� �ε���
    public int checkoutPoint = 4;  // ���밡 �ִ� ��������Ʈ�� �ε���

    private int currentWaypointIndex = 0;  // ���� ��ǥ ��������Ʈ�� �ε���
    private float waitTimer;  // ��������Ʈ���� ����ϴ� Ÿ�̸�
    private bool hasSelectedProduct = false;  // ��ǰ�� �����ߴ��� ����
    private TanghuluRequest tanghuluRequest;  // ���ķ� ��û ��ũ��Ʈ ����

    private bool isProductSelected = false;  // ���ķ縦 �����ߴ��� ����
    private bool isCheckoutReady = false;    // ��� �غ� �Ǿ����� ����

    void Start()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        MoveToNextWaypoint();
        tanghuluRequest = FindObjectOfType<TanghuluRequest>();  // ���ķ� ��û ��ũ��Ʈ ã��
    }

    void Update()
    {
        // ��������Ʈ�� �����ߴ��� �˻�
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // ��������Ʈ���� ���
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                // ���ķ� ���� �Ǵ� ���뿡�� ����
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
            MoveTowardsWaypoint();
        }

        // ���ķ� ���� ����
        if (currentWaypointIndex == productSelectionPoint && !isProductSelected)
        {
            SelectProduct();
            ShowThoughtBubble();  // ��ǳ�� ǥ�� �Լ� ȣ��
        }

        // ���뿡�� ���� ����
        if (currentWaypointIndex == checkoutPoint && isCheckoutReady)
        {
            Checkout();
        }

    }

    void MoveTowardsWaypoint()
    {
        // ���� ��������Ʈ�� �̵�
        Vector2 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }

    void MoveToNextWaypoint()
    {
        // ���� ��������Ʈ�� �̵� ����
        waitTimer = waitTime;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void SelectProduct()
    {
        isProductSelected = true;
        tanghuluRequest.RequestTanghulu();
        isCheckoutReady = true;  // ��� �غ� ���·� ����
    }

    void ShowThoughtBubble()
    {
        // ��ǳ�� ǥ�� ����
        // ��: ��ǳ�� ������Ʈ Ȱ��ȭ �Ǵ� UI ��� ǥ��
    }
    void Checkout()
    {
        if (hasSelectedProduct)
        {
            tanghuluRequest.CalculatePrice();
            isCheckoutReady = false;  // ���� �� ��� �غ� ���� ����
            isProductSelected = false; // ��ǰ ���� ���� ����
        }
    }
}
