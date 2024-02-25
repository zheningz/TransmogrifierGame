using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    void Start()
    {
        transform.Find("StartButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            });

        transform.Find("QuitButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                #if UNITY_EDITOR
                                UnityEditor.EditorApplication.Exit(0);
                #else
                            Application.Quit();
                #endif
            });
    }
}