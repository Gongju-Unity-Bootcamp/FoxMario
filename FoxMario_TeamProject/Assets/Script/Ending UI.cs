using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using JetBrains.Annotations;

namespace Ending
{
    //플레이어 사망 관련 전체 내역
    class EndingUI : MonoBehaviour
    {

        //플레이어 사망카운트 초기화
        private string sceneSave;
        public float setDieDelay = 2f;
        public static int sceneCount = 3;
        private float dieCount = 0;
        public Text countText;

        public void Start()
        {
            //변경된 사망카운트를 PlayerPrefs에 "SceneSwitchCount"로 인트 타입으로 저장하기로함
            PlayerPrefs.SetString("SceneSave", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            

            dieCount = 0;
            Txt();

        }
        public void Update()
        {
            //코루틴 대신 사용할거
            //OnTimeCheck(PlayerDie.isDied);

            // Space 클릭시 GoPreviousScene 실행
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //PlayerDie.isDied = false;
                GoPreviousScene();
            }
            // R키 입력시 사망카운트 초기화
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.DeleteAll();
            }

        }

        //private void OnTimeCheck(bool _isActived)
        //{
        //    //코루틴 대신 사용할거
        //    if (_isActived)
        //    {
        //        dieCount += Time.deltaTime;

        //        if (dieCount > setDieDelay)
        //        {
        //            GoToNextScene();
        //        }
        //    }
        //    else
        //    {
        //        dieCount = 0;
        //    }
        //}

        public void GoToNextScene()
        {
            //사망카운트 -1하며 변경된 내용을 저장하고 Die씬으로 변경
            PlayerPrefs.Save();
            SceneManager.LoadScene("Die");
        }

        public void GoPreviousScene()
        {   // 인게임 씬으로 전환
            SceneManager.LoadScene(PlayerPrefs.GetString("PrevSceneName"));
            //SceneManager.LoadScene(SceneSave); < 원래의 코드
        }

        public void Txt()
        {
            // 저장된 사망카운트를 불러옴
            PlayerPrefs.SetInt("DieCount", sceneCount);
            countText.text = "" + PlayerPrefs.GetInt("DieCount"); // $"{sceneCount}" 도 사용가능

        }

    }
}