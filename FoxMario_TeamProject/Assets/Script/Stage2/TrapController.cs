using UnityEngine;

public class TrapController : MonoBehaviour
{
    // �̵� �ӵ�
    public float speed;

    // ��ǥ ��ġ
    Vector3 targetPos;

    // �̵� ���
    public GameObject ways;
    public Transform[] wayPoints;

    // ���� �ε����� �̵� ����
    int pointIndex;
    int pointCount;
    int direction = 1;

    // Ʈ�� Ȱ��ȭ ����
    private bool activatedD = false;
    private bool activatedE = false;
    private bool activatedG = false;
    private bool activatedH = false;

    private void Awake()
    {
        // �̵� ����� �ڽ� ������ �°� �迭 �ʱ�ȭ
        wayPoints = new Transform[ways.transform.childCount];

        // �� �ڽ��� Transform�� �迭�� ����
        for (int index = 0; index < ways.gameObject.transform.childCount; ++index)
        {
            wayPoints[index] = ways.transform.GetChild(index).gameObject.transform;
        }
    }

    private void Start()
    {
        // �̵� ����� �� ������ �ʱ� �ε��� ����
        pointCount = wayPoints.Length;
        pointIndex = 1;

        // �ʱ� ��ǥ ��ġ ����
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update()
    {
        // Ʈ���� Ȱ��ȭ�Ǿ��� ���� ����
        if (activatedD)
        {
            // �̵� �ӵ��� ���� ��ǥ ��ġ�� �̵�
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // ���� ��ġ�� ��ǥ ��ġ�� �����ϸ� ���� �������� �̵�
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

        // Ʈ���� Ȱ��ȭ�Ǿ��� ���� ����
        if (activatedE)
        {
            // �̵� �ӵ��� ���� ��ǥ ��ġ�� �̵�
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // ���� ��ġ�� ��ǥ ��ġ�� �����ϸ� ���� �������� �̵�
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

        if (activatedG)
        {
            // �̵� �ӵ��� ���� ��ǥ ��ġ�� �̵�
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // ���� ��ġ�� ��ǥ ��ġ�� �����ϸ� ���� �������� �̵�
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

        if (activatedH)
        {
            // �̵� �ӵ��� ���� ��ǥ ��ġ�� �̵�
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // ���� ��ġ�� ��ǥ ��ġ�� �����ϸ� ���� �������� �̵�
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }
    }

    // ���� �̵� �������� ����
    void NextPoint()
    {
        // �̵� ���⿡ ���� ���� �ε��� ����
        pointIndex += direction;

        // ���� pointIndex�� ������ �ε����� �Ѿ�� ó������ ���ư�
        if (pointIndex >= pointCount)
        {
            pointIndex = 0;
        }
        // ���� pointIndex�� 0���� �۾����� ������ �ε����� �̵�
        else if (pointIndex < 0)
        {
            pointIndex = pointCount - 1;
        }

        // ���ο� ��ǥ ��ġ ����
        targetPos = wayPoints[pointIndex].transform.position;
    }

    // Ʈ�� Ȱ��ȭ �޼���
    public void ActivateTrapD()
    {
        activatedD = true;
    }
    public void ActivateTrapE()
    {
        activatedE = true;
    }
    public void ActivateTrapG()
    {
        activatedE = true;
    }
    public void ActivateTrapH()
    {
        activatedH = true;
    }
}
