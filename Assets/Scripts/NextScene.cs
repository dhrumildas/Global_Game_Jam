using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private UnityEditor.SceneAsset nextScene;
#endif

    public void NextSceneButton()
    {
#if UNITY_EDITOR
        if (nextScene != null)
        {
            SceneManager.LoadScene(nextScene.name);
        }
        else
        {
            Debug.LogError("Next scene not assigned!");
        }
#else
        Debug.LogError("Scene selection only works in editor!");
#endif
    }
}
