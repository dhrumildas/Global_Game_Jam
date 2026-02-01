using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause: MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;

    private bool isPaused = false;

    private void Start()
    {
        if (pausePanel) pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pausePanel) pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            NPC_Events.RaiseGamePaused(true);
        }
        else
        {
            Time.timeScale = 1f;
            if (pausePanel) pausePanel.SetActive(false);
            pauseButton.SetActive(true);
            NPC_Events.RaiseGamePaused(false);
        }
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void ResumeGame()
    {
        TogglePause();
    }
}