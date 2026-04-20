using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public static SceneLoader instance;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("EndScreen");
    }
}
