using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Синглтон для легкого доступа из других скриптов
    public static GameManager Instance;

    // Событие для обновления UI времени
    public static event Action<int, int> OnTimeChanged;

    [Header("Time Settings")]
    public int startHour = 18;
    public int totalHours = 6;
    public int currentHour;
    public int currentMinute;

    [Header("UI References - TextMeshPro")]
    public TextMeshProUGUI timeDisplayText; // Изменено на TextMeshProUGUI
    public TextMeshProUGUI descriptionText; // Изменено на TextMeshProUGUI

    private void Awake()
    {
        // Реализация синглтона
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentHour = startHour;
        currentMinute = 0;
        UpdateTimeDisplay();
    }

    // Метод для траты времени
    public void SpendTime(int hours, int minutes)
    {
        currentMinute += minutes;
        if (currentMinute >= 60)
        {
            hours++;
            currentMinute -= 60;
        }

        currentHour += hours;

        // Проверка на окончание времени
        if (currentHour >= startHour + totalHours)
        {
            TriggerEnding("TimeOut");
        }

        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        if (timeDisplayText != null)
        {
            timeDisplayText.text = $"Time: {currentHour:D2}:{currentMinute:D2}";
        }
        OnTimeChanged?.Invoke(currentHour, currentMinute);
    }

    public void TriggerEnding(string endingCode)
    {
        Debug.Log($"Концовка активирована: {endingCode}");
        // SceneManager.LoadScene(endingCode);
    }

    // Метод для обновления описания (можно вызывать из других скриптов)
    public void SetDescriptionText(string text)
    {
        if (descriptionText != null)
        {
            descriptionText.text = text;
        }
    }

    // Метод для очистки описания
    public void ClearDescriptionText()
    {
        if (descriptionText != null)
        {
            descriptionText.text = "";
        }
    }
}