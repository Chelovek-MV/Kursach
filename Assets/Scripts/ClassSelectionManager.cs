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
                tankText.text = "\nÕן 20 וה.\nCךמנמסעü 6 ף.ו.";
                speedsterText.text = "\nÕן 10 וה.\nCךמנמסעü 8 ף.ו.";
                break;
            case 2:
                tankText.text = "\nÕן 15 וה.\nCךמנמסעü 5 ף.ו.";
                speedsterText.text = "\nÕן 5 וה.\nCךמנמסעü 7 ף.ו.";
                break;
            case 3:
                tankText.text = "\nÕן 10 וה.\nCךמנמסעü 4 ף.ו.";
                speedsterText.text = "\nÕן 1 וה.\nCךמנמסעü 6 ף.ו.";
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