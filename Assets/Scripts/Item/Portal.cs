using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject playerOVR;
    public Vector3 position = new Vector3(171.169998f, 4.51999998f + 2.0f, -102.989998f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOVR.transform.position = position;
        }
    }
}
