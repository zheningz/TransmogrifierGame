using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase
{
    public abstract string GetName();
    public abstract void EnterScene();
    public abstract void ExitScene();
}
