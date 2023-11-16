using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public float SpeedDown = 1f;
    public float SpeedUp = -1f;
    public float SpeedRight = 1f;
    public float SpeedLeft = -1f;
    //public float tiltAnglet = -90f;
    public Transform bee;

    //public GameObject move;
    public Rigidbody2D monste_rd;
    public SpriteRenderer sRenderer;
    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        monsterMove();
        monste_rd.GetComponent<Rigidbody2D>();
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void monsterMove()
    {
        monste_rd.velocity = new Vector2(SpeedRight, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (isMove)
        //{
            if (other.gameObject.CompareTag("TriggerDown"))
            {
                //sRenderer.flipY = true;
                monste_rd.velocity = new Vector2(0, SpeedDown);
                bee.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            }
            if (other.gameObject.CompareTag("TriggerUp"))
            {
                //sRenderer.flipY = false;
                monste_rd.velocity = new Vector2(0, SpeedUp);
                bee.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }
            if (other.gameObject.CompareTag("TriggerLeft"))
            {
                sRenderer.flipX = true;
                monste_rd.velocity = new Vector2(SpeedLeft, 0);
                bee.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            if (other.gameObject.CompareTag("TriggerRight"))
            {
                sRenderer.flipX = true;
                monste_rd.velocity = new Vector2(SpeedRight, 0);
                bee.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        //}
    }
}