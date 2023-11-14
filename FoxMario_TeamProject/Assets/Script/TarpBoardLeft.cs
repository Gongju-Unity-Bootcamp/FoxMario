using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TarpBoard : MonoBehaviour
{
    private float BoardPositionX = 121.5f;
    private float BoardPositionY = 7.32f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = new Vector2(BoardPositionX, BoardPositionY);
    }

}
