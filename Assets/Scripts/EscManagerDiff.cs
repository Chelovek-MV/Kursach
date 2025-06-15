using UnityEngine;
using UnityEngine.SceneManagement;

public class EscManagerDiff : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}