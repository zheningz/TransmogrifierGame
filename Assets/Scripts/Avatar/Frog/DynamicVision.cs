using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicVision : MonoBehaviour
{
    public float timeScale = 0.5f;
    public GameObject flyingItem;

    float defaultTimeScale = 1.0f;
    bool timeToggle = false;
    HighlightPlus.HighlightEffect highlight;
    Animator anim;

    private void Start()
    {
        highlight  = flyingItem.GetComponent<HighlightPlus.HighlightEffect>();
        highlight.highlighted = false;
        anim = flyingItem.GetComponent<Animator>();
        anim.speed = defaultTimeScale;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            highlight.highlighted = !highlight.highlighted;
            timeToggle = !timeToggle;
            anim.speed = timeToggle ? timeScale : defaultTimeScale;
        }
    }
}
