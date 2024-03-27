using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject box;
    public GameObject openedBox;
    public GameObject key;

    private void Start()
    {
        box.SetActive(true);
        openedBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (key.GetComponent<Key>().isObtained)
            {
                box.SetActive(false);
                openedBox.SetActive(true);
            }
        }
    }
}
