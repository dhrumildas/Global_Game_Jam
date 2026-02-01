using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event System.Action DayEnded;

    [Header("Timer UI")]
    [SerializeField] private TMP_Text timerText;

    [Header("Timer Settings")]
    [SerializeField] private float GameDuration = 120f; // 3 minutes

    public float elapsed;
    private float START_HOUR = 10f; // 10 AM
    private float TOTAL_HOURS = 7f; // From 10 AM to 5 PM
    private bool isTimerRunning = true;

    private void Update()
    {
        if (!isTimerRunning) return;
        

        elapsed += Time.deltaTime;

        float t = Mathf.Clamp01(elapsed / GameDuration);
        float currentGameHour = START_HOUR + TOTAL_HOURS * t;

        UpdateTimerText(currentGameHour);

        if (elapsed >= GameDuration)
        {
            isTimerRunning = false;
            OnDayEnded();
        }
    }

    void UpdateTimerText(float float_hour)
    {
        int hour = Mathf.FloorToInt(float_hour);
        int minutes = Mathf.FloorToInt((float_hour -  hour) * 60);

        bool isPM = hour >= 12;
        int displayHour = hour % 12;
        if (displayHour == 0)
            displayHour = 12;
        string AM_PM = isPM ? "PM" : "AM";
        timerText.text = $"{displayHour:00} : {minutes:00} {AM_PM}";
    }

    void OnDayEnded()
    {
        Debug.Log("Day ended: 5 PM Reached");
        DayEnded?.Invoke();
    }
}
