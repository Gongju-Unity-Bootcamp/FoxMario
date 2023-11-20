using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    //public float speed = 50f;
    private Rigidbody rigid;
    //private GameObject[] traps;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rigid = GetComponent<Rigidbody>();
            //rigid.velocity = new Vector3(0, speed, 0);

        }
    }
}
