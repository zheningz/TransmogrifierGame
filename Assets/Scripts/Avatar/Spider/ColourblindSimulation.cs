using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourblindController : MonoBehaviour
{
    public GameObject postProcessing;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            postProcessing.SetActive(!postProcessing.activeSelf);
        }
    }
}
