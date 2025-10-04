using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �������� ��� ������� ������� �� ������ ��������
    public static GameManager Instance;

    // ������� ��� ���������� UI �������
    public static event Action<int, int> OnTimeChanged;

    [Header("Time Settings")]
    public int startHour = 18;
    public int totalHours = 6;
    public int currentHour;
    public int currentMinute;

    [Header("UI References - TextMeshPro")]
    public TextMeshProUGUI timeDisplayText; // �������� �� TextMeshProUGUI
    public TextMeshProUGUI descriptionText; // �������� �� TextMeshProUGUI

    private void Awake()
    {
        // ���������� ���������
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

    // ����� ��� ����� �������
    public void SpendTime(int hours, int minutes)
    {
        currentMinute += minutes;
        if (currentMinute >= 60)
        {
            hours++;
            currentMinute -= 60;
        }

        currentHour += hours;

        // �������� �� ��������� �������
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
        Debug.Log($"�������� ������������: {endingCode}");
        // SceneManager.LoadScene(endingCode);
    }

    // ����� ��� ���������� �������� (����� �������� �� ������ ��������)
    public void SetDescriptionText(string text)
    {
        if (descriptionText != null)
        {
            descriptionText.text = text;
        }
    }

    // ����� ��� ������� ��������
    public void ClearDescriptionText()
    {
        if (descriptionText != null)
        {
            descriptionText.text = "";
        }
    }
}