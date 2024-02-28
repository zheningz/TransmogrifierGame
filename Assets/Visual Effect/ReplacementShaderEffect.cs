using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ReplacementShaderEffect : MonoBehaviour
{
    public Color color;
    public float slider;
    public Shader replacementShader;

    void OnValidate()
    {
        Shader.SetGlobalColor("_Color_1", color);
    }

    private void Update()
    {
        Shader.SetGlobalFloat("_Temp", slider);
    }

    void OnEnable()
    {
        if (replacementShader != null)
            GetComponent<Camera>().SetReplacementShader(replacementShader, "");
    }

    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }

}