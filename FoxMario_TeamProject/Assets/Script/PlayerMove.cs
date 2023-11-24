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
        // �ٴڿ� ������ ���� ���� ���·� ����
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
        // �ӵ� ����
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
        //����� EndingUI ��ũ��Ʈ ����
        //ending.Start();
        Respawn();
    }
    private void Respawn()
    {
        isDied = true;
        PlayerPrefs.SetString("PrevSceneName", SceneManager.GetActiveScene().name);
        // 2�� ������ ����
        //SceneManager.LoadScene("Die");
        //�����m����������
        
    }
}