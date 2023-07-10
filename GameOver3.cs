using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver3 : MonoBehaviour
{
    public GameObject gameOverUI;
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
