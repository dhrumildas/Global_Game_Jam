using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private bool isMainMenu;

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnQuitClicked()
    {
        if(isMainMenu)
        {
          Application.Quit();  
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
