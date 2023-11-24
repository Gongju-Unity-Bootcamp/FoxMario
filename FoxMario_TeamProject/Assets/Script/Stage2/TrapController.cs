using UnityEngine;

public class TrapController : MonoBehaviour
{
    // 이동 속도
    public float speed;

    // 목표 위치
    Vector3 targetPos;

    // 이동 경로
    public GameObject ways;
    public Transform[] wayPoints;

    // 현재 인덱스와 이동 방향
    int pointIndex;
    int pointCount;
    int direction = 1;

    // 트랩 활성화 여부
    private bool activatedD = false;
    private bool activatedE = false;
    private bool activatedG = false;
    private bool activatedH = false;

    private void Awake()
    {
        // 이동 경로의 자식 개수에 맞게 배열 초기화
        wayPoints = new Transform[ways.transform.childCount];

        // 각 자식의 Transform을 배열에 저장
        for (int index = 0; index < ways.gameObject.transform.childCount; ++index)
        {
            wayPoints[index] = ways.transform.GetChild(index).gameObject.transform;
        }
    }

    private void Start()
    {
        // 이동 경로의 총 개수와 초기 인덱스 설정
        pointCount = wayPoints.Length;
        pointIndex = 1;

        // 초기 목표 위치 설정
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update()
    {
        // 트랩이 활성화되었을 때만 실행
        if (activatedD)
        {
            // 이동 속도에 따라 목표 위치로 이동
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // 현재 위치가 목표 위치에 도달하면 다음 지점으로 이동
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

        // 트랩이 활성화되었을 때만 실행
        if (activatedE)
        {
            // 이동 속도에 따라 목표 위치로 이동
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // 현재 위치가 목표 위치에 도달하면 다음 지점으로 이동
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

        if (activatedG)
        {
            // 이동 속도에 따라 목표 위치로 이동
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // 현재 위치가 목표 위치에 도달하면 다음 지점으로 이동
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

        if (activatedH)
        {
            // 이동 속도에 따라 목표 위치로 이동
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            // 현재 위치가 목표 위치에 도달하면 다음 지점으로 이동
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }
    }

    // 다음 이동 지점으로 설정
    void NextPoint()
    {
        // 이동 방향에 따라 현재 인덱스 조절
        pointIndex += direction;

        // 만약 pointIndex가 마지막 인덱스를 넘어가면 처음으로 돌아감
        if (pointIndex >= pointCount)
        {
            pointIndex = 0;
        }
        // 만약 pointIndex가 0보다 작아지면 마지막 인덱스로 이동
        else if (pointIndex < 0)
        {
            pointIndex = pointCount - 1;
        }

        // 새로운 목표 위치 설정
        targetPos = wayPoints[pointIndex].transform.position;
    }

    // 트랩 활성화 메서드
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
