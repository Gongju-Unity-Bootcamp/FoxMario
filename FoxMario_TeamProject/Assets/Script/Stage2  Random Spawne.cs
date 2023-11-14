using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Randomspawne : MonoBehaviour
{
    public float rand = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(1, 20);
    }

    // Update is called once per frame
    void update()
    {
        //rand = Random.Range(1, 20);
        //InvokeRepeating(nameof(spawner), 1f, rand);
        Debug.Log(rand);
    }
}

