using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] GameObject[] potion;
    [SerializeField] GameObject lid;
    [SerializeField] int index = 0;

    // AudioSource audio;
    public bool isFinished => index == potion.Length;

    private void Start()
    {
        // audio = GetComponent<AudioSource>();
        // audio.playOnAwake = false;
        SetVisuals();
    }

    private void OnValidate()
    {
        SetVisuals();
    }

    public void Consume()
    {
        if (!isFinished)
        {
            index++;
            SetVisuals();
            GetComponent<AudioSource>().Play();
        }
    }

    void SetVisuals()
    {
        for (int i = 0; i < potion.Length; i++)
        {
            potion[i].SetActive(i == index);
        }
    }

}
