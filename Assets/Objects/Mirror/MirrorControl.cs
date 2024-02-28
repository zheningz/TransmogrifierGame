using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : MonoBehaviour
{
    public Transform mirror;
    public Camera mirrorCamera;
    public Transform userCamera;
    public Vector3 cameraLocalPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraLocalPos = mirror.InverseTransformPoint(userCamera.position);
        mirrorCamera.transform.localPosition = new Vector3(-cameraLocalPos.x, cameraLocalPos.y, cameraLocalPos.z);
        mirrorCamera.transform.forward = userCamera.position - mirrorCamera.transform.position;
        mirrorCamera.nearClipPlane = Vector3.Distance(mirror.position, mirrorCamera.transform.position);
    }
}
