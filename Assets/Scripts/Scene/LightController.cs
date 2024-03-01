using System.Reflection;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float percentage = 20.0f;

    void Start()
    {
        Light[] lights = FindObjectsOfType<Light>();

        foreach (var light in lights)
        {
            light.range *= percentage;
        }
    }
}
