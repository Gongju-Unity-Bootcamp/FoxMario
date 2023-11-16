using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    public float maxSpeed = 0f;
    bool isRun;
    bool isJump;
    bool ground;
    public float jump;
    public bool longJump = false;
    private Vector3 footPosition;

    public GameObject Player;
    SpriteRenderer renderer;
    Animator anime;
    CapsuleCollider2D cap;
    public LayerMask groundLayer;
    Collider2D col;
    Rigidbody2D rigid;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        isRun = false;
    }
    private void Update()
    {
        //플레이어 이동 좌표
        float Player = Input.GetAxisRaw("Horizontal");
        Vector2 newPosition = new Vector2(Player * maxSpeed, 0);
        transform.Translate(newPosition);

        //플레이어 이동 및 모션
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(Vector2.left, ForceMode2D.Impulse);
            renderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector2.right, ForceMode2D.Impulse);
            renderer.flipX = Input.GetAxisRaw("Horizontal") == 0;
        }
        if (Mathf.Abs(rigid.velocity.x) > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed * Mathf.Sign(rigid.velocity.x), rigid.velocity.y);
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (Mathf.Abs(rigid.velocity.x) > 0.5f)
            {
                rigid.AddForce(Vector2.left * Mathf.Sign(rigid.velocity.x), ForceMode2D.Impulse);
            }
            else
            {
                {
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                }
            }
        }
        //점프

        if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (!isJump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            isJump = true;

        }
        if(longJump && rigid.velocity.y > 0)
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
        if (Mathf.Abs(Player) > 0f)
        {
            anime.SetBool("isRun", true);
        }
        else
        {
            anime.SetBool("isRun", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJump = false;
            Debug.Log("Jump :" + isJump);
        }

    }

}
