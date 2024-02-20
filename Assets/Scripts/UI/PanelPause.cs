using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelPause : MonoBehaviour
{
    public void ContinueGame()
    {
        GameManager.GetInstance().sceneController_root.Continue();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Spider-VR");
    }

    public void QuitToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
