using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string chmFileName = "Help.chm"; // Имя файла в папке StreamingAssets
    public void PlayGame()
    {
        SceneManager.LoadScene("DiffSelectoin");
    }

    public void OpenHelp()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, chmFileName);

        if (File.Exists(filePath))
        {
            Process.Start(filePath);
        }
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}