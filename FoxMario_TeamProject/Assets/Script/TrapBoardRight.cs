using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBoardRight : MonoBehaviour
{
    private float BoardPositionX = 125f;
    private float BoardPositionY = 7.32f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Move();
        }
    }

    void Move()
    {

        transform.position = new Vector2(BoardPositionX, BoardPositionY);

    }
}
