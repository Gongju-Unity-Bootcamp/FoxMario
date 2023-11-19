using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using Unity.VisualScripting;
using DieText;


namespace Ending
{
 
    class EndingUI : MonoBehaviour
    {   
        //�÷��̾� ���ī��Ʈ �ʱ�ȭ
        private int sceneCount = 0;


        public void Start()
        {
            Debug.Log("����");
            //����� ���ī��Ʈ�� PlayerPrefs�� "SceneSwitchCount"�� �����ϱ����
            sceneCount = PlayerPrefs.GetInt("SceneSwitchCount", 0);
            //3�ʵ� GoTonextScene ����
            Invoke("GoToNextScene", 3f);
            Invoke("CancleAllInvoke", 4f);

        }
        public void GoToNextScene()
        {
            //���ī��Ʈ -1�ϸ� ����� ������ �����ϰ� Die������ ����
            sceneCount--;
            PlayerPrefs.SetInt("SceneSwitchCount", sceneCount);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Die");
        }

        public void CancleAllInvoke()
        {
            CancelInvoke();
        }
        public void St1_Nest()
        {
            SceneManager.LoadScene("stage_2");
        }
    }
}