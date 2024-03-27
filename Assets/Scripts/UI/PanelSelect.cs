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
                SceneManager.LoadScene("Spider-Train");
            });

        transform.Find("BatButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Bat-Train");
            });

        transform.Find("FrogButton").GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Frog-Train");
            });
    }
}
