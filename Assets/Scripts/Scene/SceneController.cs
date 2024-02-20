using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;

    public SceneBase gameScene;

    public static SceneController GetInstance()
    {
        if (instance == null)
        {
            return instance;
        }

        return instance;
    }

    public void ReloadScene()
    {
        LoadScene(gameScene.GetName(), gameScene);
    }

    public void LoadScene(string sceneName, SceneBase sceneBase)
    {
        gameScene = sceneBase;

        SceneManager.LoadScene(sceneName);
        sceneBase.EnterScene();
    }

    public void Pause()
    {
        if (gameScene != null)
        {
            Time.timeScale = 0;
            gameScene.ExitScene();
        }
        SceneManager.LoadScene("Paused");
    }

    public void Continue()
    {
        // unload pause scene
        if (gameScene != null)
        {
            SceneManager.UnloadSceneAsync("Paused");
            Time.timeScale = 1;
        }
    }
}
