using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ending;
using System.Threading;
using FallingManagername;

namespace Player
{

    public class PlayerDie : MonoBehaviour
    {
        FallingManager fallingtrigger = new FallingManager();
        private EndingUI ending = new EndingUI();
        private Vector3 initialPosition;
        public static bool isDied;
        string[] sceneNames = new string[3]{"Stage1 JH", "stage2_gang", "ending"};

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

            if (collision.gameObject.CompareTag("NextScene"))
            {
                NextScene();
            }

        }


        public void Die()
        {
            Debug.Log("Player Die...!");
            //사망시 EndingUI 스크립트 실행
            Respawn();
        }
        private void Respawn()
        {
            isDied = true;
            PlayerPrefs.SetString("PrevSceneName", SceneManager.GetActiveScene().name);

        }
        
        
        private void NextScene()
        {
            string realScene = SceneManager.GetActiveScene().name;

            for (int index = 0; index < sceneNames.Length; index++) 
            {
                if (sceneNames[index] == realScene)
                {
                    SceneManager.LoadScene(sceneNames[index + 1]);
                }
            }
        }

    }
}
