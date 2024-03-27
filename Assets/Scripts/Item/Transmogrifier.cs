using UnityEngine;
using UnityEngine.SceneManagement;

public enum AvatarType
{
    Spider,
    Bat,
    Frog,
    Human
}

public class Transmogrifier : MonoBehaviour
{
    public AvatarType avatar;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Transmogrify");
        if (other.tag == "Player")
        {
            Debug.Log("Transmogrify!");
            switch (avatar)
            {
                case AvatarType.Spider:
                    SceneManager.LoadScene("Spider-Dungeon");
                    break;
                case AvatarType.Bat:
                    SceneManager.LoadScene("Bat-Dungeon");
                    break;
                case AvatarType.Frog:
                    SceneManager.LoadScene("Frog-Dungeon");
                    break;
                case AvatarType.Human:
                    SceneManager.LoadScene("Home-Dungeon");
                    break;
            }
        }
    }
}
