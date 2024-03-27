using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isObtained = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isObtained = true;
            gameObject.SetActive(false);
        }
    }
}
