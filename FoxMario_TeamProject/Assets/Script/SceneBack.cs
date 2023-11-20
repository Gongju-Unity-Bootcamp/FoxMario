using Ending;
using Player;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Back
{
    public class SceneBack : MonoBehaviour
    {
        public void Update()
        {
            // Space 클릭시 GoPreviousScene 실행
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerDie.isDied = false;
                GoPreviousScene();
            }
            // R키 입력시 사망카운트 초기화
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        public void GoPreviousScene()
        {   // 인게임 씬으로 전환
            SceneManager.LoadScene("EndingText2");
        }
    }
}