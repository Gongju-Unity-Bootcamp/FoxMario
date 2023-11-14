using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool isRun;
    bool isJump;
    public float jump;
    public GameObject Player;
    SpriteRenderer renderer;
    Animator anime;

    // Start is called before the first frame update
    Rigidbody2D rigid;
    //private void Awake()
    //{
    //    rigid = GetComponent<Rigidbody2D>();  
    //}
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        isRun = false;
    }
    private void Update()
    {


        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            renderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            renderer.flipX = Input.GetAxisRaw("Horizontal") == 0;
        }
        float Player = Input.GetAxisRaw("Horizontal");
        Vector2 newPosition = new Vector2(Player * maxSpeed, 0);
        transform.Translate(newPosition);
        if(!isJump && Input.GetButtonDown("Jump"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            isJump = true;
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
