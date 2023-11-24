using System;
using UnityEngine;

[Serializable]
public class FallTrap
{
    //public string name;
    public GameObject gameObject;
    public bool isActived;
    public float scale;
}

public class TrapManager : MonoBehaviour
{
    [SerializeField] private FallTrap[] fallTrap;

    private void OnTriggerEnter2D(Collider2D _hit)
    {
        if (_hit.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < fallTrap.Length; ++i)
            {
                if (_hit.gameObject == fallTrap[i].gameObject)
                {
                    fallTrap[i].isActived = true;
                    fallTrap[i].gameObject.GetComponent<Rigidbody2D>().simulated = false;
                    fallTrap[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = fallTrap[i].scale;
                }
            }
        }
    }
}
