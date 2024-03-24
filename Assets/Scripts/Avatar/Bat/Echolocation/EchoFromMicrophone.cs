using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoFromMicrophone : MonoBehaviour
{
    public GameObject waveSphere;
    public Transform player;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.2f;

    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness > threshold)
            Instantiate(waveSphere, player.position, Quaternion.identity);
    }
}
