using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelStart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Spider-VR");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.Exit(0);
        #else
            Application.Quit();
        #endif
    }
}
