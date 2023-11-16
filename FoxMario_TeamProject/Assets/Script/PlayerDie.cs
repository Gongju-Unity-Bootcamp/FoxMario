using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player Die...!");
        Respawn();
    }
    private void Respawn()
    {
        transform.position = initialPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
