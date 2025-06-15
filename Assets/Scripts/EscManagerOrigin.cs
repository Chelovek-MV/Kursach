using UnityEngine;
using UnityEngine.SceneManagement;

public class EscManagerOrigin : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("DiffSelectoin");
        }
    }
}