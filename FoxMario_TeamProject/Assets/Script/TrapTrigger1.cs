using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger1 : MonoBehaviour
{
    GameObject Traptrigger1;
    public Rigidbody2D Falling;
    public Transform FallingTraptrigger;
    public float speed = 5f;
    public float DeleteTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Falling.simulated = true;
            Destroy(Falling.gameObject, DeleteTime);
        }
    }
}
