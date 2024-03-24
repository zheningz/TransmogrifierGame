using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echolocation : MonoBehaviour
{
    public GameObject waveSphere;
    public Transform player;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(waveSphere, player.position, Quaternion.identity);
        }
    }
}
