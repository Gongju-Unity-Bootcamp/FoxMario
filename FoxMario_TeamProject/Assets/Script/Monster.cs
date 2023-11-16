using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject monster;
    public float Speed = -1f;
    public float RightSpeed = 1f;
    public GameObject Leftwill;
    public GameObject Rightwill;
    private SpriteRenderer sRenderer;
    private Rigidbody2D rigib;
    void Start()
    {
        Move();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Move()
    {
        rigib = GetComponent<Rigidbody2D>();
        rigib.velocity = new Vector2(Speed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("LeftWill"))
        //{
        //    //rigib.velocity = new Vector2(-Speed, 0);
        //    Speed *= -1f;
        //}

        //if (Speed == -1f)
        //{
        //    sRenderer.flipX = false;
        //}

        //else if (Speed == 1f)
        //{
        //    sRenderer.flipX = true;
        //}
        if (other.gameObject.CompareTag("LeftWill"))
        {
            sRenderer.flipX = true;
            rigib.velocity = new Vector2(RightSpeed, 0);
            Debug.Log("gg");
        }

        if (other.gameObject.CompareTag("RightWill"))
        {
            sRenderer.flipX = false;
            rigib.velocity = new Vector2(Speed, 0);
        }
    }
}
