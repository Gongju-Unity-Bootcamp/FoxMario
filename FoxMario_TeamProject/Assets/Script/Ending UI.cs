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


namespace Ending
{
    //�÷��̾� ��� ���� ��ü ����
    class EndingUI : MonoBehaviour
    {

        //�÷��̾� ���ī��Ʈ �ʱ�ȭ
        private string sceneSave;
        public float setDieDelay = 2f;
        private int sceneCount = 0;
        private float dieCount = 0;
        private Text countText;

        public void Start()
        {
            //����� ���ī��Ʈ�� PlayerPrefs�� "SceneSwitchCount"�� ��Ʈ Ÿ������ �����ϱ����
            sceneCount = PlayerPrefs.GetInt("SceneSwitchCount", 3);
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
            sceneCount--;
            PlayerPrefs.SetInt("SceneSwitchCount", sceneCount);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Die");
        }

        public void GoPreviousScene()
        {   // �ΰ��� ������ ��ȯ
            SceneManager.LoadScene(PlayerPrefs.GetString("SceneSave"));
            //SceneManager.LoadScene(SceneSave); < ������ �ڵ�
        }

        public void Txt()
        {
            // ����� ���ī��Ʈ�� �ҷ���
            int sceneCount = PlayerPrefs.GetInt("SceneSwitchCount");

            countText.text = "" + sceneCount; // $"{sceneCount}" �� ��밡��

        }

    }
}