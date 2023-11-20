using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ending;
using System.Threading;

namespace Player
{
    public class PlayerDie : MonoBehaviour
    {
        private EndingUI ending = new EndingUI();
        private Vector3 initialPosition;
        public static bool isDied;
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


        public void Die()
        {
            Debug.Log("Player Die...!");
            //사망시 EndingUI 스크립트 실행
            //ending.Start();
            Respawn();
        }
        private void Respawn()
        {
            isDied = true;
            PlayerPrefs.SetString("PrevSceneName", SceneManager.GetActiveScene().name);
            // 2초 딜레이 예정
            //SceneManager.LoadScene("Die");
        }
    

    }
}
