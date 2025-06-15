using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // Текст для отображения времени
    public static event System.Action OnMinutePassed; // Событие, вызываемое каждую минуту

    private float elapsedTime = 0f; // Прошедшее время
    private float mobTime = 0f;
    private bool isRunning = true; // Флаг для контроля работы таймера

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            mobTime += Time.deltaTime;

            // Обновляем текст таймера
            if (timerText != null)
            {
                int minutes = Mathf.FloorToInt(elapsedTime / 60);
                int seconds = Mathf.FloorToInt(elapsedTime % 60);
                timerText.text = $"Время: {minutes:D2}:{seconds:D2}";
            }

            // Проверяем, прошла ли минута
            if (mobTime >= 60f)
            {
                mobTime -= 60f; // Сбрасываем таймер на следующую минуту
                OnMinutePassed?.Invoke(); // Вызываем событие
                Debug.Log("One minute has passed!");
            }
        }
    }

    public void StopTimer()
    {
        isRunning = false; // Останавливаем таймер
    }

    public float GetElapsedTime()
    {
        return elapsedTime; // Возвращаем прошедшее время
    }
}