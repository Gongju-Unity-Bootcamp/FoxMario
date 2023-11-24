using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripTest_st2 : MonoBehaviour
{
    public Collider2D triggerA;
    public Collider2D triggerB;
    public Collider2D triggerC;
    public Collider2D triggerD;
    public Collider2D triggerE;
    public Collider2D triggerF;
    public Collider2D triggerG;
    public Collider2D triggerH;
    public Collider2D triggerI;

    public GameObject wallA;
    public GameObject trapB;
    public GameObject fishC;
    public GameObject trapC;
    public GameObject trapD;
    public GameObject trapE;
    public GameObject monsterG;
    public GameObject monsterH;

    private bool breakA = false;
    private float timerA = 4f;
    private bool deleteWallA = false;

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
                // Trig2-A에 닿았을 때의 동작
                breakA = true;
                deleteWallA = true;
                triggerA.enabled = false;

                // SpriteRenderer를 비활성화
                SpriteRenderer spriteRendererA = triggerA.GetComponent<SpriteRenderer>();
                if (spriteRendererA != null)
                {
                    spriteRendererA.enabled = false;
                }

                // 오브젝트 B를 찾아서 비활성화
                if (triggerB != null)
                {
                    triggerB.enabled = false;
                }
            }
            else if (gameObject.CompareTag("Trig2-B"))
            {
                // Trig2-B에 닿았을 때의 동작
                triggerA.gameObject.SetActive(false);
                triggerB.enabled = false;

                trapB.gameObject.SetActive(true);
            }
            else if (gameObject.CompareTag("Trig2-C"))
            {
                // Trig2-C에 닿았을 때의 동작
                trapC.SetActive(true);
            }
            else if (gameObject.CompareTag("Trig2-D"))
            {
                // Trig2-D에 닿았을 때의 동작
                trapD.SetActive(true);
                TrapController trapDController = trapD.GetComponent<TrapController>();

                if (trapDController != null)
                {
                    trapDController.ActivateTrapD();
                }

                triggerD.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-E"))
            {
                // Trig2-E에 닿았을 때의 동작
                trapE.SetActive(true);
                TrapController trapEController = trapE.GetComponent<TrapController>();

                if (trapEController != null)
                {
                    trapEController.ActivateTrapE();
                }

                triggerE.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-F"))
            {
                // Trig2-F에 닿았을 때의 동작
                // SpriteRenderer를 비활성화
                SpriteRenderer spriteRendererF = triggerF.GetComponent<SpriteRenderer>();
                if (spriteRendererF != null)
                {
                    spriteRendererF.enabled = false;
                }

                if (triggerG != null)
                {
                    triggerG.enabled = false;
                }
                triggerF.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-G"))
            {
                // Trig2-G에 닿았을 때의 동작
                monsterG.SetActive(true);
                TrapController trapGController = monsterG.GetComponent<TrapController>();

                if (trapGController != null)
                {
                    trapGController.ActivateTrapG();
                }

                triggerF.gameObject.SetActive(false);
                triggerG.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-H"))
            {
                // Trig2-H에 닿았을 때의 동작
                monsterH.SetActive(true);
                TrapController trapHController = monsterH.GetComponent<TrapController>();

                if (trapHController != null)
                {
                    trapHController.ActivateTrapH();
                }

                triggerH.enabled = false;
            }
            else if (gameObject.CompareTag("Trig2-I"))
            {
                // Trig2-I에 닿았을 때의 동작
                PlayerController_2 playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController_2>();

                // PlayerController_2 스크립트의 maxSpeed * 0.1 로 변경
                if (playerController != null)
                {
                    playerController.maxSpeed *= 0.1f;
                }
            }
        }
    }

    private void BreakWallA()
    {
        // Trig2-A에 닿았을 때의 동작
        if (breakA)
        {
            timerA -= Time.deltaTime;

            if (deleteWallA && timerA < 0f)
            {
                if (wallA != null)
                {
                    wallA.SetActive(false);
                }
            }
        }
    }
}
