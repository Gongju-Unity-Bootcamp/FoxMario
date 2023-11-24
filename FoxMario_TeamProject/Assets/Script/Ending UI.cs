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
    //�÷��̾� ��� ���� ��ü ����
    class EndingUI : MonoBehaviour
    {

        //�÷��̾� ���ī��Ʈ �ʱ�ȭ
        private string sceneSave;
        public float setDieDelay = 2f;
        public static int sceneCount = 3;
        private float dieCount = 0;
        public Text countText;

        public void Start()
        {
            //����� ���ī��Ʈ�� PlayerPrefs�� "SceneSwitchCount"�� ��Ʈ Ÿ������ �����ϱ����
            PlayerPrefs.SetString("SceneSave", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            

            dieCount = 0;
            Txt();

        }
        public void Update()
        {
            //�ڷ�ƾ ��� ����Ұ�
            //OnTimeCheck(PlayerDie.isDied);

            // Space Ŭ���� GoPreviousScene ����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //PlayerDie.isDied = false;
                GoPreviousScene();
            }
            // RŰ �Է½� ���ī��Ʈ �ʱ�ȭ
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.DeleteAll();
            }

        }

        //private void OnTimeCheck(bool _isActived)
        //{
        //    //�ڷ�ƾ ��� ����Ұ�
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
            //���ī��Ʈ -1�ϸ� ����� ������ �����ϰ� Die������ ����
            PlayerPrefs.Save();
            SceneManager.LoadScene("Die");
        }

        public void GoPreviousScene()
        {   // �ΰ��� ������ ��ȯ
            SceneManager.LoadScene(PlayerPrefs.GetString("PrevSceneName"));
            //SceneManager.LoadScene(SceneSave); < ������ �ڵ�
        }

        public void Txt()
        {
            // ����� ���ī��Ʈ�� �ҷ���
            PlayerPrefs.SetInt("DieCount", sceneCount);
            countText.text = "" + PlayerPrefs.GetInt("DieCount"); // $"{sceneCount}" �� ��밡��

        }

    }
}