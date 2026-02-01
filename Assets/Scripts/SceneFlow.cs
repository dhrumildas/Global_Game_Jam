using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string failSceneName = "FailScene";
    [SerializeField] private string nextLevelSceneName = "Stage2"; // Or "ResultsScreen"

    private void OnEnable()
    {
        NPC_Events.OnLevelFailed += LoadFailScene;
        NPC_Events.OnLevelComplete += LoadNextLevel;
    }

    private void OnDisable()
    {
        NPC_Events.OnLevelFailed -= LoadFailScene;
        NPC_Events.OnLevelComplete -= LoadNextLevel;
    }

    private void LoadFailScene()
    {
        // Ensure time is running before switching scenes
        Time.timeScale = 1f;
        SceneManager.LoadScene(failSceneName);
    }

    private void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevelSceneName);
    }
}