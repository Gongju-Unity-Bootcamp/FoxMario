using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripTest_st2 : MonoBehaviour
{
    public Collider2D triggerA;
    public Collider2D triggerB;
    public GameObject wallA;
    public GameObject fishC;
    private float timerA = 10f;
    private bool testA = false;     // ����� Ȯ��

    private void Update()
    {
        timerA -= Time.deltaTime ;

        if (testA && timerA < 0f)
        {
            if (wallA != null)
            {
                wallA.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Trigger2-A"))
            {
                //Debug.Log("Player touched Trigger A");
                //testA = true;

                // ������Ʈ B�� ã�Ƽ� ��Ȱ��ȭ
                if (triggerB != null)
                {
                    triggerB.enabled = false;
                }
                triggerA.enabled = false;
            }
            // �÷��̾ ������Ʈ B�� ����� ��
            else if (gameObject.CompareTag("Trigger2-B"))
            {
                //Debug.Log("Player touched Trigger B");
                triggerA.enabled = false;
            }

            else if (gameObject.CompareTag("Trigger2-C"))
            {
                // fishC.transform.position.y = new Vector3();
            }
        }

    }
}

