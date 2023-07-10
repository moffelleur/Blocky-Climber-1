using UnityEngine;
using UnityEngine.SceneManagement;

public class newfinishscript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //go to next level
            SceneManager.LoadScene("Main Menu");
        }
    }
}

