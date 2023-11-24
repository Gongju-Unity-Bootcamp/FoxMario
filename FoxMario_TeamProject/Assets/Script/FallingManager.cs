using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingManagername
{
    public class FallingManager : MonoBehaviour
    {
        public Rigidbody2D[] falling;
        public GameObject[] fallingTrigger;
        private float speed = 10f;
        public void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("1234");
                for (int i = 0; i < falling.Length; ++i)
                {
                    if (falling[i] != null)
                    {
                        falling[i] = falling[i].GetComponent<Rigidbody2D>();
                        falling[i].simulated = true;
                        //falling[i].gravityScale = speed;
                        Debug.Log("ggg");
                    }
                }
            }

        }
        public void FallingStart(int x)
        {
            falling[x] = falling[x].GetComponent<Rigidbody2D>();
            falling[x].simulated = true;
            //falling[i].gravityScale = speed;
            Debug.Log("ggg");
        }
    }
}
