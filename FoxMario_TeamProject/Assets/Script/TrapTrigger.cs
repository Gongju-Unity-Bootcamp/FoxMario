using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TrapTriggerStart : MonoBehaviour
{
    GameObject TrapTrigger;
    GameObject Player;
    public GameObject RockSpawnerPoint;
    public GameObject RockPrefab;
    public float speed = 3f;


    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag( "Player"))
        {
            InvokeRepeating(nameof(spawner), 0.01f, 3600f);
        }

    }
    void spawner()
    {
        GameObject Rock = Instantiate(RockPrefab, RockSpawnerPoint.transform.position, transform.rotation);
        Destroy(Rock, speed);
    }
}

          