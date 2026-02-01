using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfDayManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject gameplayPanel; // The "current" panel to disable
    [SerializeField] private GameObject resultsPanel;  // The "new" panel to enable

    private void OnEnable()
    {
        // Subscribe to the DayEnded event from GameTimer
        if (gameTimer != null)
            gameTimer.DayEnded += StartEndSequence;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        if (gameTimer != null)
            gameTimer.DayEnded -= StartEndSequence;
    }

    private void StartEndSequence()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        int countdownValue = 5;
        countdownText.gameObject.SetActive(true);

        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }

        countdownText.text = "0";
        yield return new WaitForSeconds(0.5f); // Brief pause at 0

        // Switch panels
        if (gameplayPanel != null) gameplayPanel.SetActive(false);
        if (resultsPanel != null) resultsPanel.SetActive(true);

        countdownText.gameObject.SetActive(false);
    }
}