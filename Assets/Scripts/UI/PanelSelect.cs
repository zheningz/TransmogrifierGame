using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelSelect : MonoBehaviour
{
    void Start()
    {
        transform.Find("SpiderButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Spider-Dungeon");
            });

        transform.Find("BatButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Bat-Dungeon");
            });

        transform.Find("CatButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                // SceneManager.LoadScene("HomeScene");
            });
    }
}
