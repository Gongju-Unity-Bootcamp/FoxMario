using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StalactiteTrigger : MonoBehaviour
{
    public GameObject[] Board;
    public GameObject Player;
    
    bool boardStart = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < Board.Length; ++i)
            {
                Board[i].SetActive(true);
            }
        }

    }
}
