using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class DeathScreenManager : MonoBehaviour
{
    public static DeathScreenManager Instance;

    public GameObject deathScreen;
    public Text survivalTimeText;
    public Text killCountText;
    public Text scoreText;
    public string mainMenuSceneName = "MainMenu"; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDeathScreen(float survivalTime)
    {
        int diffSelection = DiffSelectionManager.SelectedDiff;
        int minutes = Mathf.FloorToInt(survivalTime / 60);
        int seconds = Mathf.FloorToInt(survivalTime % 60);
        float survivalScore = survivalTime * 10;
        float killScore = KillCounter.Instance.killCount * 100;
        float diff = 0;
        switch (diffSelection)
        {
            case 1:
                diff = 0.5f;
                break;
            case 2:
                diff = 1f;
                break;
            case 3:
                diff = 1.5f;
                break;
        }
        Debug.Log(diff);
        float totalScore = (survivalScore + killScore) * diff;
        int currentMaxScore = PlayerPrefs.GetInt("score", 0);
        if (totalScore > currentMaxScore)
        {
            PlayerPrefs.SetInt("score", (int)totalScore); // Сохраняем новый рекорд
            PlayerPrefs.Save();
        }

        switch (diffSelection)
        {
            case 1:
                int currentEasyScore = PlayerPrefs.GetInt("easyScore", 0);
                if (totalScore > currentEasyScore)
                {
                    PlayerPrefs.SetInt("easyScore", (int)totalScore); // Сохраняем новый рекорд
                    PlayerPrefs.Save();
                }
                break;
            case 2:
                int currentNormalScore = PlayerPrefs.GetInt("normalScore", 0);
                if (totalScore > currentNormalScore)
                {
                    PlayerPrefs.SetInt("normalScore", (int)totalScore); // Сохраняем новый рекорд
                    PlayerPrefs.Save();
                }
                break;
            case 3:
                int currentHardScore = PlayerPrefs.GetInt("hardScore", 0);
                if (totalScore > currentHardScore)
                {
                    PlayerPrefs.SetInt("hardScore", (int)totalScore); // Сохраняем новый рекорд
                    PlayerPrefs.Save();
                }
                break;
        }

        

        survivalTimeText.text = $"Вы продержались:\n{minutes:D2}:{seconds:D2}";
        killCountText.text = $"Врагов уничтожено:\n{KillCounter.Instance.killCount}";
        scoreText.text = $"Счёт:\n{Mathf.FloorToInt(totalScore)}";

        deathScreen.SetActive(true);
        CanvasGroup canvasGroup = deathScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }
}