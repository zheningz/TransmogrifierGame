using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicVision : MonoBehaviour
{
    public float timeScale = 0.5f;

    float defaultTimeScale = 1.0f;
    float defaultFixedDeltaTime = 0.02f;
    bool timeToggle = false;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            timeToggle = !timeToggle;
            Time.timeScale = timeToggle ? timeScale : defaultTimeScale;
            Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
        }
    }
}
