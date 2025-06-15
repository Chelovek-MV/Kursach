using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiffSelectionManager : MonoBehaviour
{
    public static int SelectedDiff = 0;

    public Button normalButton;
    public Button hardButton;

    public Text normal;
    public Text hard;
    public Text score;

    public int requiredScoreForNormal = 5000;
    public int requiredScoreForHard = 5000;
    void Start()
    {
        int easyScore = PlayerPrefs.GetInt("easyScore", 0);
        int normalScore = PlayerPrefs.GetInt("normalScore", 0);
        int hardScore = PlayerPrefs.GetInt("hardScore", 0);
        int totalScore = PlayerPrefs.GetInt("score", 0);

        if (totalScore >= requiredScoreForNormal)
        {
            normalButton.interactable = true;
            normal.text = $"";
        }
        else
        {
            normalButton.interactable = false;
            normal.text = $"(Чтобы разблокировать наберите {requiredScoreForNormal} очков)";
        }

        if (totalScore >= requiredScoreForHard)
        {
            hardButton.interactable = true;
            hard.text = $"";
        }
        else
        {
            hardButton.interactable = false;
            hard.text = $"(Чтобы разблокировать наберите {requiredScoreForHard} очков)";
        }

        score.text = $"Максимальный счёт:\n{totalScore}";
    }

    public void Easy()
    {
        SelectedDiff = 1;
        LoadGameScene();
    }

    public void Normal()
    {
        SelectedDiff = 2;
        LoadGameScene();
    }
    public void Hard()
    {
        SelectedDiff = 3;
        LoadGameScene();
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("ClassSelection");
    }
}