using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRaunch : MonoBehaviour
{
    GameObject Player;
    public GameObject MushroomPrefab;
    public float ForceMagnitude = 5f;
    public Transform TrapBox;
    // Start is called before the first frame update

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating(nameof(Raunch), 0.1f, 3600f);
        }
    }

    void Raunch()
    {
        GameObject newRaunch = Instantiate(MushroomPrefab, TrapBox.position, TrapBox.rotation);
        //Unity에서 rigidbody를 부여해도되나 그냥 넣어봄.
        Rigidbody2D rigidbody = newRaunch.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(1, ForceMagnitude);
        rigidbody.AddForce(force * 2, ForceMode2D.Impulse);
       

    }
}
