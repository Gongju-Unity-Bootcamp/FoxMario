using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject FloorTrigger;
    GameObject player;
    public float speed = 50f;
    private Rigidbody rigid;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D ohder)
    {

        if (ohder.gameObject.tag == "Player")
        {
            rigid = GetComponent<Rigidbody>();
            rigid.velocity = new Vector3(0, speed, 0);

        }
    }
}