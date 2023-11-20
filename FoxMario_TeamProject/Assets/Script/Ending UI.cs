using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using Unity.VisualScripting;
using DieText;
using Player;
using UnityEditor.Experimental.GraphView;

namespace Ending
{
 
    class EndingUI : MonoBehaviour
    {
        //플레이어 사망카운트 초기화
        public float setDieDelay = 2f;
        private int sceneCount = 0;
        private float dieCount = 0;

        public void Start()
        {
            //변경된 사망카운트를 PlayerPrefs에 "SceneSwitchCount"로 저장하기로함
            sceneCount = PlayerPrefs.GetInt("SceneSwitchCount", 3);
            dieCount = 0;

        }
        public void Update()
        {
            OnTimeCheck(PlayerDie.isDied);
        }

        private void OnTimeCheck(bool _isActived)
        {
            if (_isActived)
            {
                dieCount += Time.deltaTime;

                if (dieCount > setDieDelay)
                {
                    GoToNextScene();
                }
            }
            else
            {
                dieCount = 0;
            }
        }

        public void GoToNextScene()
        {
            //사망카운트 -1하며 변경된 내용을 저장하고 Die씬으로 변경
            sceneCount--;
            PlayerPrefs.SetInt("SceneSwitchCount", sceneCount);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Die");
        }

 
    }
}