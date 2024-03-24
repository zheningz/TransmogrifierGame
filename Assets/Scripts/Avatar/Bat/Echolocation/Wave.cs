using UnityEngine;

public class Wave : MonoBehaviour
{
    public float speed = 1.0f;
    public float destroyThreshold = 50.0f;

    void Update()
    {
        transform.localScale += Vector3.one * speed * Time.deltaTime;

        if (transform.localScale.x > destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
