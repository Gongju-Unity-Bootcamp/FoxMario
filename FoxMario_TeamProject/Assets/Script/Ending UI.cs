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
        //�÷��̾� ���ī��Ʈ �ʱ�ȭ
        public float setDieDelay = 2f;
        private int sceneCount = 0;
        private float dieCount = 0;

        public void Start()
        {
            //����� ���ī��Ʈ�� PlayerPrefs�� "SceneSwitchCount"�� �����ϱ����
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
            //���ī��Ʈ -1�ϸ� ����� ������ �����ϰ� Die������ ����
            sceneCount--;
            PlayerPrefs.SetInt("SceneSwitchCount", sceneCount);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Die");
        }

 
    }
}