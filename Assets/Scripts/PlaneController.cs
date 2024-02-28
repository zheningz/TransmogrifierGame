using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    GameObject VrCamera;

    // Start is called before the first frame update
    void Start()
    {
        VrCamera = GameObject.Find("CenterEyeAnchor");
        Vector3 startPos = new Vector3(0, (float)(VrCamera.transform.position.y + 0.6f), 0);
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
