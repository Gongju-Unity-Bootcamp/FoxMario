using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 10f;
    public GameObject Player;
    SpriteRenderer renderer;
    Animator anime;

    // Start is called before the first frame update
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector3(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            renderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            renderer.flipX = Input.GetAxisRaw("Horizontal") == 0;
        }
        if(Mathf.Abs(rigid.velocity.x) < 0.1f)
        {
            anime.SetBool("isRun", false);
        }
        else
        {
            anime.SetBool("isRun", true);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float Player = Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = new Vector3(Player * maxSpeed, 0, 0);
        transform.Translate(newPosition);

        //if (rigid.velocity.x > maxSpeed)
        //{
        //    rigid.velocity = new Vector3(maxSpeed, rigid.velocity.y, 0);
        //}
        //else if (rigid.velocity.x < maxSpeed * -1)
        //{
        //    rigid.velocity = new Vector3(maxSpeed * -1, rigid.velocity.y, 0);
        //}
    }
}
