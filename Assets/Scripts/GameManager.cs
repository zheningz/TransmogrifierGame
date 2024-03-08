using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            SceneManager.LoadScene("Paused");
        }
    }
}
