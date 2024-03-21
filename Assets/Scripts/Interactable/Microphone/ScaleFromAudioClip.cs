using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale = new Vector3(1, 1, 1);
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    void Update()
    {
        float loudness = detector.GetLoudness(source.timeSamples, source.clip);

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
