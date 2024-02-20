using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private SceneController sceneController;
    public SceneController sceneController_root { get => sceneController; }

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            return instance;
        }

        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        instance = this;
        sceneController = new SceneController();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Paused" || SceneManager.GetActiveScene().name != "HomeScene")
        {
            if (OVRInput.Get(OVRInput.Button.Start))
            {
                sceneController_root.Pause();
            }
        }
    }
}
