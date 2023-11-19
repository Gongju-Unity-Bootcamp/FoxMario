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

            // �߷��� �ݴ�� �ٲ�
            trapDRigidbody.gravityScale = 1;

            // ���� �ð� �Ŀ� ������Ʈ �ı�
            Destroy(gameObject, deleteTime);
        }
    }
}
