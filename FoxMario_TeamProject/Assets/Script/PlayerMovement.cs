using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 8.0f;
    public bool longJump = false;

    private Rigidbody2D rigid;

    private LayerMask groundLayer;
    private CapsuleCollider2D capsule2D;
    private bool ground;
    private Vector3 footPosition;

    private int maxJumpCount = 2;


    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsule2D = GetComponent<CapsuleCollider2D>();
    }
    private void FixedUpdate()
    {
        Bounds bounds = capsule2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        ground = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if(longJump && rigid.velocity.y > 0)
        {
            rigid.gravityScale = 1.0f;
        }
        else
        {
            rigid.gravityScale = 2.5f;
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(footPosition, 0.1f);
        
    //}
    public void Move(float x)
    {
        rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
    }
    public void Jump()
    {
        rigid.velocity = Vector2.up * jumpForce;
    }
        
}
