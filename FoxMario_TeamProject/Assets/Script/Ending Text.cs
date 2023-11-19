using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DieText
{
 
    public class EndingText : MonoBehaviour
    {

        public Text countText;
        public void Start()
        {
            //sceneCount = PlayerPrefs.GetFloat("SceneCount", 0);
            int sceneCount = PlayerPrefs.GetInt("SceneSwitchCount", 0);
            Txt();
        }

        public void Txt()
        {
            int sceneCount = PlayerPrefs.GetInt("SceneSwitchCount", 0);
            countText.text = "" + sceneCount;

        }

    }
}