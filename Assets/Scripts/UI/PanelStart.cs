using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelStart : MonoBehaviour
{
    public GameObject items;

    void Start()
    {
        items.SetActive(false);

        transform.Find("StartButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                items.SetActive(true);
                gameObject.SetActive(false);
            });

        transform.Find("TrainButton").GetComponent<Button>()
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
