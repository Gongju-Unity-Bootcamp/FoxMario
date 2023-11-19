using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapD : MonoBehaviour
{
    public Rigidbody2D trapDRigidbody;
    private float deleteTime = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("test");

            // 중력을 반대로 바꿈
            trapDRigidbody.gravityScale = 1;

            // 일정 시간 후에 오브젝트 파괴
            Destroy(gameObject, deleteTime);
        }
    }
}
