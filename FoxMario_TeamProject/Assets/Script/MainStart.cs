using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainStart : MonoBehaviour
{
    public RectTransform[] btnTransform;
    public Button buttonPosition;
    public int btnIndex;

    private void Start()
    {
        btnIndex = 0;
    }


    public void OnClick()
    {
        if (btnIndex != btnTransform.Length)
        {
            buttonPosition.transform.position = btnTransform[btnIndex].position;
            ++btnIndex;
        }
        else
        {
            SceneManager.LoadScene("Stage1 test");
        }
    }
}
