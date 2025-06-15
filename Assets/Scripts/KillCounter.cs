using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public static KillCounter Instance { get; private set; }

    public Text killCounterText;
    public int killCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of KillCounter detected!");
            Destroy(gameObject);
        }
    }

    public void AddKill()
    {
        killCount++;
        UpdateKillCounterText();
    }

    void UpdateKillCounterText()
    {
        if (killCounterText != null)
        {
            killCounterText.text = $"\n{killCount}";
        }
    }
}