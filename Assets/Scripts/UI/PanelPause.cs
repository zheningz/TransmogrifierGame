using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelPause : MonoBehaviour
{
    void Start()
    {
        transform.Find("RestartButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Spider-VR");
            });

        transform.Find("QuitButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("HomeScene");
            });
    }
}
