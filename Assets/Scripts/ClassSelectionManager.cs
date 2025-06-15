using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClassSelectionManager : MonoBehaviour
{
    public static int playerHealthBonus = 0;
    public static float playerSpeedBonus = 0f;
    public Text tankText;
    public Text speedsterText;

    void Start()
    {
        switch (DiffSelectionManager.SelectedDiff)
        {
            case 1:
                tankText.text = "\n�� 20 ��.\nC������� 6 �.�.";
                speedsterText.text = "\n�� 10 ��.\nC������� 8 �.�.";
                break;
            case 2:
                tankText.text = "\n�� 15 ��.\nC������� 5 �.�.";
                speedsterText.text = "\n�� 5 ��.\nC������� 7 �.�.";
                break;
            case 3:
                tankText.text = "\n�� 10 ��.\nC������� 4 �.�.";
                speedsterText.text = "\n�� 1 ��.\nC������� 6 �.�.";
                break;

        }
    }

    public void SelectTank()
    {
        playerHealthBonus = 5;
        playerSpeedBonus = -1f;
        Debug.Log("Class selected: Tank");
        LoadGameScene();
    }

    public void SelectSpeedster()
    {
        playerHealthBonus = -5;
        playerSpeedBonus = 1f;
        Debug.Log("Class selected: Speedster");
        LoadGameScene();
    }

    void LoadGameScene()
    {
        switch (DiffSelectionManager.SelectedDiff)
        {
            case 1:
                SceneManager.LoadScene("EasyDiff");
                break;
            case 2:
                SceneManager.LoadScene("NormalDiff");
                break;
            case 3:
                SceneManager.LoadScene("HardDiff");
                break;

        }
    }
}