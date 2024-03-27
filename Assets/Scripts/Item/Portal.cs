using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject playerOVR;
    public GameObject otherPortal;
    public float yOffset = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOVR.transform.position = otherPortal.transform.position + new Vector3(0, yOffset, 0);
        }
    }
}
