using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStalactite : MonoBehaviour
{
    public float distance;
    bool isFalling = false;
    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if(isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
            
            if(hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    rigid.gravityScale = 5;
                    isFalling = true;
                }
            }
        }
    }
}
