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
            // Space Ŭ���� GoPreviousScene ����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerDie.isDied = false;
                GoPreviousScene();
            }
            // RŰ �Է½� ���ī��Ʈ �ʱ�ȭ
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        public void GoPreviousScene()
        {   // �ΰ��� ������ ��ȯ
            SceneManager.LoadScene("EndingText2");
        }
    }
}