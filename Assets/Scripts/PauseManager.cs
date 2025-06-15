using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isPausedEsc = false;
    public GameObject pauseScreen;
    public GameObject pauseScreenEsc;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEsc();
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        isPausedEsc = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void ToggleEsc()
    {
        if (!isPaused)
        {
            if (!isPausedEsc)
            {
                PauseGameEsc();
            }
            else
            {
                ResumeGameEsc();
            }
        }
    }

    void PauseGameEsc()
    {

        Time.timeScale = 0f;
        CanvasGroup canvasGroup = pauseScreenEsc.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        isPausedEsc = true;
        Debug.Log("Game paused.");
    }

    public void ResumeGameEsc()
    {
        Time.timeScale = 1f;
        CanvasGroup canvasGroup = pauseScreenEsc.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        isPausedEsc = false;
        Debug.Log("Game resumed.");
    }

    public void TogglePause()
    {
        if (!isPausedEsc)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        
        Time.timeScale = 0f;
        CanvasGroup canvasGroup = pauseScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Debug.Log("Game paused.");
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        CanvasGroup canvasGroup = pauseScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Debug.Log("Game resumed.");
    }
}