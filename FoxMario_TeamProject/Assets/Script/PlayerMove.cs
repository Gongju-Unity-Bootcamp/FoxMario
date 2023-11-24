using Ending;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 0.1f;
    bool isJump;
    public float jump = 1f;
    public bool longJump = false;
    public static bool isDied;

    private EndingUI ending = new EndingUI();
    public GameObject Player;
    SpriteRenderer renderer;
    Animator anime;
    Rigidbody2D rigid;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    private void Update()
    {
        MovePlayer();
        CheckRunAnimation();
        Jump();
    }
    void MovePlayer()
    {
        float player = Input.GetAxisRaw("Horizontal");
        Move(player);
        
    }
    void Jump()
    {
        if (!isJump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            isJump = true;
        }

        if (longJump && rigid.velocity.y > 0)
        {
            rigid.gravityScale = 1.0f;
        }
        else
        {
            rigid.gravityScale = 4f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            longJump = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            longJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿으면 점프 가능 상태로 변경
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    void Move(float player)
    {
        Vector2 newPosition = new Vector2(player * maxSpeed, 0);
        transform.Translate(newPosition);

        if(player != 0)
        {
            rigid.AddForce(new Vector2(player * maxSpeed, 0), ForceMode2D.Impulse);
            renderer.flipX = player == -1;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rigid.velocity = Vector2.zero;
        }
        LimitVelocity();
    }
    void LimitVelocity()
    {
        // 속도 제한
        if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
    }
    void CheckRunAnimation()
    {
        float player = Input.GetAxisRaw("Horizontal");
        anime.SetBool("isRun", Mathf.Abs(player) > 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Player Die...!");
        //사망시 EndingUI 스크립트 실행
        //ending.Start();
        Respawn();
    }
    private void Respawn()
    {
        isDied = true;
        PlayerPrefs.SetString("PrevSceneName", SceneManager.GetActiveScene().name);
        // 2초 딜레이 예정
        //SceneManager.LoadScene("Die");
        //으헤헿히히히히히
        
    }
}