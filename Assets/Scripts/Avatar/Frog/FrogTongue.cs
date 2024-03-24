using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering.PostProcessing;

public class FrogTongue : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        // animation
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Tongue");
        }
    }
}
