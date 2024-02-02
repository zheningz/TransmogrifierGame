using UnityEngine;

public class ConsumerController : MonoBehaviour
{
    Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Potion potion = other.GetComponent<Potion>();
        if (potion != null && !potion.isFinished)
        {
            potion.Consume();
        }
    }
}
