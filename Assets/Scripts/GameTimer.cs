using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // ����� ��� ����������� �������
    public static event System.Action OnMinutePassed; // �������, ���������� ������ ������

    private float elapsedTime = 0f; // ��������� �����
    private float mobTime = 0f;
    private bool isRunning = true; // ���� ��� �������� ������ �������

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            mobTime += Time.deltaTime;

            // ��������� ����� �������
            if (timerText != null)
            {
                int minutes = Mathf.FloorToInt(elapsedTime / 60);
                int seconds = Mathf.FloorToInt(elapsedTime % 60);
                timerText.text = $"�����: {minutes:D2}:{seconds:D2}";
            }

            // ���������, ������ �� ������
            if (mobTime >= 60f)
            {
                mobTime -= 60f; // ���������� ������ �� ��������� ������
                OnMinutePassed?.Invoke(); // �������� �������
                Debug.Log("One minute has passed!");
            }
        }
    }

    public void StopTimer()
    {
        isRunning = false; // ������������� ������
    }

    public float GetElapsedTime()
    {
        return elapsedTime; // ���������� ��������� �����
    }
}