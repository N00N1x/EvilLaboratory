using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject quitConfirmationUI; 

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (quitConfirmationUI != null)
        {
            quitConfirmationUI.SetActive(false);
        }
    }

    void Update()
    {
        if (gameOverUI != null && gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void gameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        if (quitConfirmationUI != null)
        {
            quitConfirmationUI.SetActive(true);
           Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("Quit Confirmation UI is not assigned in the Inspector. Quitting directly.");
            Application.Quit();
        }
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void CancelQuit()
    {
        if (quitConfirmationUI != null)
        {
            quitConfirmationUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void start()
    {
        SceneManager.LoadScene("Sara Scene");
    }
}