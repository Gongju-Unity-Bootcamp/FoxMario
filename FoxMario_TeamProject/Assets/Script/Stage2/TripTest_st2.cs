using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripTest_st2 : MonoBehaviour
{
    public Collider2D TriggerA;
    public Collider2D TriggerB;
    public Collider2D TriggerC;
    public Collider2D TriggerD;
    public Collider2D TriggerE;
    public Collider2D TriggerF;
    public Collider2D TriggerG;


    public GameObject WallA;
    public GameObject FishC;
    public GameObject TrapC;

    public Rigidbody2D TrapD;

    private float TimerA = 10f;
    private bool DeleteWallA = false;
    private float DeleteTime = 5f;

    private void Update()
    {
        BreakWallA();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Trig2-A"))
            {
                DeleteWallA = true;
                TriggerA.enabled = false;

                // 오브젝트 B를 찾아서 비활성화
                if (TriggerB != null)
                {
                    TriggerB.enabled = false;
                }
            }
            else if (gameObject.CompareTag("Trig2-B"))
            {
                TriggerA.enabled = false;
                TriggerB.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-C"))
            {
                TrapC.SetActive(true);
            }
            else if (gameObject.CompareTag("Trig2-D"))
            {
                TrapD.simulated = true;
            }
            else if (gameObject.CompareTag("Trig2-E"))
            {

            }
            else if (gameObject.CompareTag("Trig2-F"))
            {
                
                if (TriggerG != null)
                {
                    TriggerG.enabled = false;
                }
                TriggerF.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-G"))
            {
                TriggerG.enabled = false;
            }
        }
    }

    private void BreakWallA()
    {
        TimerA -= Time.deltaTime;

        if (DeleteWallA && TimerA < 0f)
        {
            if (WallA != null)
            {
                WallA.SetActive(false);
            }

        }
    }
}

