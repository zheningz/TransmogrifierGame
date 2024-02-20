using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScene : SceneBase
{
    public readonly string sceneName = "SpiderScene";
    public override void EnterScene()
    {
        Time.timeScale = 1;
    }

    public override void ExitScene()
    {
        Time.timeScale = 0;
    }

    public override string GetName()
    {
        return sceneName;
    }
}
