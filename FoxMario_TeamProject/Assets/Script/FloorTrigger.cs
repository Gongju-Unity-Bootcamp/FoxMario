using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    //public float speed = 50f;
    private Rigidbody rigid;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D ohder)
    {

        if (ohder.gameObject.CompareTag("Player"))
        {
            rigid = GetComponent<Rigidbody>();
            //rigid.velocity = new Vector3(0, speed, 0);

        }
    }
}
