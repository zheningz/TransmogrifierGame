using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject UIHelper;

    private void Start()
    {
        canvas.SetActive(false);
        UIHelper.SetActive(false);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            canvas.SetActive(!canvas.activeSelf);
            UIHelper.SetActive(!UIHelper.activeSelf);
        }
    }
}
