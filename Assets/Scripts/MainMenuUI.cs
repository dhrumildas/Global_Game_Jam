using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "GameScene";

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
