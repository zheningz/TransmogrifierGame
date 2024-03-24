using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelStart : MonoBehaviour
{
    public GameObject avatar;
    public GameObject bat;

    void Start()
    {
        transform.Find("StartButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Bat-Dungeon");
/*                bat.SetActive(true);
                avatar.SetActive(false);*/
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
