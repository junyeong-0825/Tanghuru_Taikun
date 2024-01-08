using UnityEngine;

public class CustomerAI2D : MonoBehaviour
{
    public GameObject popUI;  // �˾� UI

    public Transform[] waypoints;  // �湮�� ��������Ʈ
    public Transform exitPoint;    // �ⱸ ��ġ
    public float speed = 2.0f;     // �̵� �ӵ�
    public int productSelectionPoint = 2;  // ���ķ� ���� ��������Ʈ �ε���
    public int checkoutPoint = 8;  // ���� ��������Ʈ �ε���

    private int currentWaypointIndex = 0;  // ���� ��ǥ ��������Ʈ �ε���
    private float waitTimer;               // ��������Ʈ���� ��� Ÿ�̸�
    private bool hasSelectedProduct = false;  // ��ǰ ���� ����
    private bool isExiting = false;           // �ⱸ�� �̵� ������ ����
    private TanghuluRequest tanghuluRequest;  // ���ķ� ��û ��ũ��Ʈ ����

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

        // ù ��° �湮�� ��������Ʈ�� ������ ����
        currentWaypointIndex = Random.Range(0, 8);
        waitTimer = Random.Range(1f, 2f);  // 1-2�� ��� �ð� ����

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
                Destroy(gameObject);  // �ⱸ ���� �� �մ� ����
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
                        currentWaypointIndex = checkoutPoint;  // ����� �̵�
                    }
                    else if (currentWaypointIndex == checkoutPoint)
                    {
                        Checkout();
                    }

                    // ���� ��������Ʈ�� �̵� ����
                    waitTimer = Random.Range(1f, 2f);  // 1-2�� ��� �ð� ����
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
