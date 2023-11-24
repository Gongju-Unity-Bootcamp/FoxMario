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
        public static bool isDied;

        void Start()
        {

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
            //����� EndingUI ��ũ��Ʈ ����
            //ending.Start();
            Respawn();
        }
        private void Respawn()
        {
            isDied = true;
            PlayerPrefs.SetString("PrevSceneName", SceneManager.GetActiveScene().name);
            // 2�� ������ ����
            //SceneManager.LoadScene("Die");
        }
    

    }
}
